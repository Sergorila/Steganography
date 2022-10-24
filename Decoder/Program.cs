using System;
using System.Collections.Generic;

namespace Decoder
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "";
            List<string> spath = new List<string>();
            while (true)
            {

                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i])
                    {
                        case "-h":
                            Help();
                            break;
                        case "--help":
                            Help();
                            break;
                        case "-m":
                            message = args[i + 1];
                            break;
                        case "--message":
                            message = args[i + 1];
                            break;
                        case "-s":
                            spath.Add(args[i + 1]);
                            break;
                        case "--stego":
                            spath.Add(args[i + 1]);
                            break;
                    }
                }

                if (spath.Count == 0)
                {
                    string input;
                    
                    while((input = Console.ReadLine()) != "")
                    {
                        spath.Add(input); 
                    }
                    break;
                }
                if (spath[0] != "")
                {
                    break;
                }
            }

            Reader r = new Reader(spath, message);
            r.Decoding();
        }

        public static void Help()
        {
            Console.WriteLine("-m и --message – путь к файлу, в который нужно записать сообщение в том" +
                "виде, в котором оно было до встраивания.Если не указан, то сообщение" +
                "выводится в стандартный поток вывода.");
            Console.WriteLine("-s и --stego – путь по которому нужно записать стегоконтейнер, Если не указан, то содержимое" +
                "стегоконтейнера передаётся через стандартный поток ввода.");
            Console.WriteLine("-h и --help – вывести справку.");
            Console.WriteLine("Примеры запуска:");
            Console.WriteLine("-s stegocontainer.txt --message message.txt");
            Console.WriteLine("< stegocontainer.txt > message.txt");
        }
    }
}
