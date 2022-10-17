using System;

namespace Coder
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "";
            string cpath = "";
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
                        case "-c":
                            cpath = lines[i + 1];
                            break;
                        case "--container":
                            cpath = lines[i + 1];
                            break;
                    }
                }

                if (cpath == "")
                {
                    Console.WriteLine("Путь к контейнеру должен быть указан!");
                    continue;
                }
                if (message == "")
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i] != "-c" && lines[i] != "--container" && lines[i] != "-s"
                            && lines[i] != "--stego" && !lines[i].Contains(".txt"))
                        {
                            message = lines[i];
                            break;
                        }
                    }
                }
                if (cpath != "")
                {
                    break;
                }
            }
            
            
            Writer w = new Writer(message, cpath, spath);
            w.Coding();
        }

        public static void Help()
        {
            Console.WriteLine("-m и --message – путь к файлу, содержащему сообщение. Если не указан, то" +
                "сообщение передаётся через стандартный поток ввода.");
            Console.WriteLine("-s и --stego – путь по которому нужно записать стегоконтейнер, Если не" +
                "указан, то результат выводится в стандартный поток вывода.");
            Console.WriteLine("-c и --container – путь к файлу-контейнеру. Обязательный параметр!");
            Console.WriteLine("Примеры запуска:");
            Console.WriteLine("-m message.txt -s stegocontainer.txt -c container.txt");
            Console.WriteLine("-c container.txt < message.txt >");
        }
    }
}
