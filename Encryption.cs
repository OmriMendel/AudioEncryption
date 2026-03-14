using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using NAudio.Wave;
using MathNet.Numerics.IntegralTransforms;
using System.Numerics;

namespace AudioEncryption
{
    public static class Encryption
    {
        // --- Audio Settings ---
        const int SampleRate = 44100;
        const double Volume = 0.2;
        const short Amplitude = (short)(32767 * Volume);
        const double NoteDuration = 0.01;
        const int BaseFreq = 1000;
        const int FreqStep = 10;

        public static short[] GenerateNote(int freq, double seconds)
        {
            int totalSamples = (int)(SampleRate * seconds);
            short[] noteBuffer = new short[totalSamples];

            int fadeSamples = (int)(SampleRate * 0.01);
            if (fadeSamples * 2 > totalSamples)
                fadeSamples = totalSamples / 2;

            for (int i = 0; i < totalSamples; i++)
            {
                double t = (double)i / SampleRate;
                double wave = Math.Sin(2 * Math.PI * freq * t);

                double envelope = 1.0;
                if (i < fadeSamples)
                    envelope = (double)i / fadeSamples;
                else if (i > totalSamples - fadeSamples)
                    envelope = (double)(totalSamples - i) / fadeSamples;

                noteBuffer[i] = (short)(wave * envelope * Amplitude);
            }
            return noteBuffer;
        }

        public static void EncryptToAudio(string inputFilePath, RSA rsaPublicKey, string outputWav)
        {
            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.GenerateKey();
                aes.GenerateIV();

                byte[] encryptedFileData;
                byte[] rawFileBytes = File.ReadAllBytes(inputFilePath);

                using (var encryptor = aes.CreateEncryptor())
                {
                    encryptedFileData = encryptor.TransformFinalBlock(rawFileBytes, 0, rawFileBytes.Length);
                }

                byte[] keyMaterial = aes.Key.Concat(aes.IV).ToArray();
                byte[] encryptedKeyHeader = rsaPublicKey.Encrypt(keyMaterial, RSAEncryptionPadding.Pkcs1);

                byte[] finalPayload = encryptedKeyHeader.Concat(encryptedFileData).ToArray();

                List<short> notes = new List<short>();
                foreach (byte b in finalPayload)
                {
                    int freq = BaseFreq + (b * FreqStep);
                    notes.AddRange(GenerateNote(freq, NoteDuration));
                }

                SaveWav(outputWav, notes.ToArray());
            }
        }

        public static bool DecryptFromAudio(string wavFilePath, RSA rsaKey, string outputFilePath)
        {
            Console.WriteLine("Reading audio and running FFT analysis...");
            List<byte> recoveredBytes = new List<byte>();
            int samplesPerNote = (int)(SampleRate * NoteDuration);

            int fftSize = 16384;

            Complex[] complexData = new Complex[fftSize];

            using (WaveFileReader reader = new WaveFileReader(wavFilePath))
            {
                ISampleProvider sampleProvider = reader.ToSampleProvider();
                float[] allAudio = new float[reader.SampleCount];
                sampleProvider.Read(allAudio, 0, allAudio.Length);

                for (int i = 0; i < allAudio.Length; i += samplesPerNote)
                {
                    if (i + samplesPerNote > allAudio.Length) break;

                    Array.Clear(complexData, 0, complexData.Length);

                    for (int j = 0; j < samplesPerNote; j++)
                    {
                        complexData[j] = new Complex(allAudio[i + j], 0);
                    }

                    Fourier.Forward(complexData, FourierOptions.Default);

                    double maxMagnitude = 0;
                    int peakIndex = 0;

                    for (int j = 0; j < fftSize / 2; j++)
                    {
                        double magnitude = complexData[j].Magnitude;
                        if (magnitude > maxMagnitude)
                        {
                            maxMagnitude = magnitude;
                            peakIndex = j;
                        }
                    }

                    double peakFreq = peakIndex * ((double)SampleRate / fftSize);

                    int byteVal = (int)Math.Round((peakFreq - BaseFreq) / (double)FreqStep);
                    byteVal = Math.Max(0, Math.Min(255, byteVal));
                    recoveredBytes.Add((byte)byteVal);
                }
            }

            Console.WriteLine("Audio analyzed. Reconstructing file...");

            try
            {
                byte[] rsaHeader = recoveredBytes.Take(128).ToArray();
                byte[] aesPayload = recoveredBytes.Skip(128).ToArray();

                byte[] decryptedKeyMaterial = rsaKey.Decrypt(rsaHeader, RSAEncryptionPadding.Pkcs1);

                byte[] aesKey = decryptedKeyMaterial.Take(32).ToArray();
                byte[] aesIV = decryptedKeyMaterial.Skip(32).Take(16).ToArray();

                using (Aes aes = Aes.Create())
                {
                    aes.Key = aesKey;
                    aes.IV = aesIV;

                    using (var decryptor = aes.CreateDecryptor())
                    {
                        byte[] originalFileBytes = decryptor.TransformFinalBlock(aesPayload, 0, aesPayload.Length);
                        File.WriteAllBytes(outputFilePath, originalFileBytes);
                    }
                }
                Console.WriteLine("File successfully decrypted and saved!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Decryption failed! Error: {ex.Message}");
                return false;
            }
        }

        public static void SaveWav(string filePath, short[] samples)
        {
            WaveFormat format = new WaveFormat(SampleRate, 16, 1);
            using (WaveFileWriter writer = new WaveFileWriter(filePath, format))
            {
                writer.WriteSamples(samples, 0, samples.Length);
            }
        }
    }
}