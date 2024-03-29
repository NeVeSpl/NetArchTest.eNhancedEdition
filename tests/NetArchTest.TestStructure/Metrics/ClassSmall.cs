﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NetArchTest.TestStructure.Metrics
{
    internal class ClassSmall
    {
        // This method was generated by GPT-4 Turbo :D
        public static string Foo(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            string[] words = s.Split();

            StringBuilder result = new StringBuilder();

            foreach (string word in words)
            {
                result.Append(char.ToUpper(word[0]) + word.Substring(1) + " ");
            }

            return result.ToString().Trim();
        }
    }
}
