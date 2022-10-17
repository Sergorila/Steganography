using System;

namespace Decoder
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "";
            string spath = "";
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "-h")
                {
                    Help();
                    continue;
                }
                var lines = input.Split();
                for (int i = 0; i < lines.Length; i++)
                {
                    switch (lines[i])
                    {
                        case "-m":
                            message = lines[i + 1];
                            break;
                        case "--message":
                            message = lines[i + 1];
                            break;
                        case "-s":
                            spath = lines[i + 1];
                            break;
                        case "--stego":
                            spath = lines[i + 1];
                            break;
                    }
                }

                if (spath == "")
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i] != "-m" && lines[i] != "--message" && !lines[i].Contains(".txt"))
                        {
                            spath = lines[i];
                            break;
                        }
                    }
                }
                if (message != "" && spath != "")
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
