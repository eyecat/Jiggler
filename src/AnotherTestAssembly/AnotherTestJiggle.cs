﻿using System;
using System.IO;
using System.Reflection;

namespace AnotherTestAssembly
{
    public static class AnotherTestJiggle
    {
        public static string TestStringToPassThrough { get; set; }

        public static void Jiggle()
        {
            _WriteTestOutput();
            Console.WriteLine("Jiggle");
        }

        private static void _WriteTestOutput()
        {
            if (TestStringToPassThrough != null)
            {
                var outputFilePath = _BuildOutputFilePath();
                File.WriteAllText(outputFilePath, TestStringToPassThrough);
            }
        }

        private static string _BuildOutputFilePath()
        {
            var testAssemblyBuildPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var outputFilePath = Path.Combine(testAssemblyBuildPath, "TestOutput.txt");
            Console.WriteLine("Writing TestOutput.txt to " + outputFilePath);
            return outputFilePath;
        }
    }
}
