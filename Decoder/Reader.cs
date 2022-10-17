﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Decoder
{
    public class Reader
    {
        private string _stegocontainerPath;

        public Reader(string stegocontainerPath)
        {
            _stegocontainerPath = stegocontainerPath;
        }

        public void Decoding()
        {
            StringBuilder binaryStr = new StringBuilder();

            using(StreamReader sr = new StreamReader(_stegocontainerPath))
            {
                string input;
                while((input = sr.ReadLine()) != null)
                {
                    Console.WriteLine(input);
                    if (input[^1] == ' ')
                    {
                        binaryStr.Append("1");
                    }
                    else
                    {
                        binaryStr.Append("0");
                    }
                }
            }
            string result = binaryStr.ToString();
            var stringArray = Enumerable.Range(0, result.Length / 8).Select(i => Convert.ToByte(result.Substring(i * 8, 8), 2)).ToArray();
            var str = Encoding.UTF8.GetString(stringArray);
            Console.WriteLine(str);
        }
    }
}