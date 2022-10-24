using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Decoder
{
    public class Reader
    {
        private List<string> _stegocontainerPath;
        private string _message;

        public Reader(List<string> stegocontainerPath, string message)
        {
            _message = message;
            _stegocontainerPath = new List<string>(stegocontainerPath);
        }

        public void Decoding()
        {
            StringBuilder binaryStr = new StringBuilder();

            if (_stegocontainerPath[0].Contains(".txt"))
            {
                using (StreamReader sr = new StreamReader(_stegocontainerPath[0]))
                {
                    string input;
                    while ((input = sr.ReadLine()) != null)
                    {
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
            }
            else
            {
                foreach(var item in _stegocontainerPath)
                {
                    if (item[^1] == ' ')
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
            if (result.Length % 8 != 0)
            {
                int len = 0;
                while (len + 8 <= result.Length)
                {
                    len += 7;
                }
                result = result.Substring(0, len);
                Console.WriteLine(result);
            }
            
            var stringArray = Enumerable.Range(0, result.Length / 8).Select(i => Convert.ToByte(result.Substring(i * 8, 8), 2)).ToArray();
            var str = Encoding.UTF8.GetString(stringArray);

            if (_message.Contains(".txt"))
            {
                using (StreamWriter sw = new StreamWriter(_message))
                {
                    sw.WriteLine(str);
                }
            }
            else
            {
                Console.WriteLine(str);
            }
            
        }
    }
}
