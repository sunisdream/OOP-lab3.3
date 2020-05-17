using System;
using System.IO;

namespace OOP_lab_3_6_3
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader file = new StreamReader("input.txt");

            string text = file.ReadLine();

            string[] sentences = text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            int[] lengths = new int[sentences.Length];

            int maxLengthIndex = 0;

            int index = 0;

            foreach (string sentence in sentences)
            {
                string[] words = sentence.Split(new char[] { '\n', '\r', ' ', ':', ';', ',', '(', ')', '{', '}', '[', ']', '@', '#', '№', '$', '^', '%', '&', '*', '/', '|' }, StringSplitOptions.RemoveEmptyEntries);

                lengths[index] = words.Length;

                ++index;
            }

            for (int i = 0; i < lengths.Length; ++i)
            {
                if (lengths[maxLengthIndex] <= lengths[i])
                {
                    maxLengthIndex = i;
                }
            }

            StreamWriter newFile = File.CreateText("output.txt");

            newFile.WriteLine("Найдовше речення:\n{0}", sentences[maxLengthIndex]);

            newFile.Close();
        }
    }
}
