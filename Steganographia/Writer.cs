using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coder
{
    public class Writer
    {
        private string _message;
        private string _containerPath;
        private string _stegocontainerPath;

        public Writer(string message, string containerPath, string stegocontainerPath)
        {
            _message = message;
            _containerPath = containerPath;
            _stegocontainerPath = stegocontainerPath;
        }

        public void Coding()
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in System.Text.Encoding.Unicode.GetBytes("amogus"))
                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));

            string binaryStr = sb.ToString();
            Console.WriteLine(binaryStr);

            var stringArray = Enumerable.Range(0, binaryStr.Length / 8).Select(i => Convert.ToByte(binaryStr.Substring(i * 8, 8), 2)).ToArray();
            var str = Encoding.UTF8.GetString(stringArray);
            Console.WriteLine(str);
        }
    }
}
