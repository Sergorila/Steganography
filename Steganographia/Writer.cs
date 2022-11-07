using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Coder
{
    public class Writer
    {
        private string _message;
        private string _containerPath;
        private string _stegocontainerPath;
        private List<string> _lines;
        private List<byte> _bytes;

        public Writer(string message, string containerPath, string stegocontainerPath)
        {
            byte[] bytes;
            if (message.Length != 0)
            {
                using (BinaryReader br = new BinaryReader(File.Open(message, FileMode.Open)))
                {
                    bytes = br.ReadBytes(int.MaxValue-100);
                }
            }
            else
            {
                string input = Console.ReadLine();
                bytes = Encoding.UTF8.GetBytes(input);
            }

            _bytes = bytes.ToList();
            _containerPath = containerPath;
            _stegocontainerPath = stegocontainerPath;
            _lines = new List<string>();
        }

        public void Coding()
        {
            var stopsymbol = Encoding.UTF8.GetBytes("$");
            foreach (var b in stopsymbol)
            {
                _bytes.Add(b);
            }
            StringBuilder sb = new StringBuilder();
            foreach (byte b in _bytes)
                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));

            string binaryStr = sb.ToString();
            
            using(StreamReader sr = new StreamReader(_containerPath))
            {
                string input;
                int k = 0;
                while ((input = sr.ReadLine()) != null)
                {
                    _lines.Add(input);
                    if (k < binaryStr.Length)
                    {
                        if (binaryStr[k] == '1')
                        {
                            _lines[k] += " ";
                        }
                    }
                    k++;
                }

                if (k < binaryStr.Length)
                {
                    Console.WriteLine("Container hasn't enough lines.");
                    return;
                }
            }

            if (_stegocontainerPath.Contains(".txt"))
            {
                using (StreamWriter sw = new StreamWriter(_stegocontainerPath))
                {
                    for (int i = 0; i < _lines.Count; i++)
                    {
                        sw.WriteLine(_lines[i]);
                    }
                }
            }
            else
            {
                Show();
            }
            
        }

        public void Show()
        {
            foreach (var item in _lines)
            {
                Console.WriteLine(item);
            }
        }
    }
}
