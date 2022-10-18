using System;
using System.IO;
using System.Text;

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
                            spath = args[i + 1];
                            break;
                        case "--stego":
                            spath = args[i + 1];
                            break;
                        case "-c":
                            cpath = args[i + 1];
                            break;
                        case "--container":
                            cpath = args[i + 1];
                            break;
                    }
                }

                

                if (cpath == "")
                {
                    Console.WriteLine("Путь к контейнеру должен быть указан!");
                    return;
                }
                if (message == "")
                {
                    message = Console.ReadLine();
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
