using System;
using System.Text;

namespace PassGen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int passwordLength = 20; // длина пароля по умолчанию
            int passwordCount = 1;  // количество паролей по умолчанию
            int complexityLevel = 3; // уровень сложности по умолчанию

            int version = 3; // текущая версия программы

            bool outputPass = true;

            Console.WriteLine($"        PASSGEN by Li_is v{version}");
            Console.WriteLine();
            if (args.Length == 0)
            {
                if (!File.Exists("no.help"))
                {
                    Console.WriteLine("Программа имеет дополнительнрые параметры. Используйте -h или -help для справки.", Console.ForegroundColor = ConsoleColor.DarkGray);
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }

            // Парсинг аргументов командной строки
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-h":
                    case "-help":
                        ShowHelp();
                        outputPass = false;
                        break;

                    case "-d":
                    case "-dif":
                        if (i + 1 < args.Length && int.TryParse(args[i + 1], out int level) && level >= 1 && level <= 3)
                        {
                            complexityLevel = level;
                            i++;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: для -d или -dif необходимо указать значение от 1 до 3.");
                            outputPass = false;
                        }
                        break;

                    case "-n":
                    case "-num":
                        if (i + 1 < args.Length && int.TryParse(args[i + 1], out int count) && count > 0)
                        {
                            passwordCount = count;
                            i++;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: для -n или -num необходимо указать положительное число.");
                            outputPass = false;
                        }
                        break;

                    case "-l":
                    case "-len":
                        if (i + 1 < args.Length && int.TryParse(args[i + 1], out int length) && length > 0)
                        {
                            passwordLength = length;
                            i++;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: для -l или -len необходимо указать положительное число.");
                            outputPass = false;
                        }
                        break;

                    default:
                        Console.WriteLine($"Неизвестный параметр: {args[i]}. Используйте -h или -help для справки.");
                        outputPass = false;
                        break;
                }
            }
            if (outputPass)
            {
                GenerateAndDisplayPasswords(passwordLength, passwordCount, complexityLevel);
                Console.WriteLine();
                Console.WriteLine("Любая клавиша для выхода.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Любая клавиша для выхода.");
                Console.ReadKey();
            }
        }

        static void ShowHelp()
        {
            Console.WriteLine("------------- ПОМОЩЬ -------------");
            Console.WriteLine("-h или -help         : Показать это сообщение.");
            Console.WriteLine("-d или -dif [1-3]    : Уровень сложности пароля (1 - цифры, 2 - цифры и буквы, 3 - цифры, буквы и символы).");
            Console.WriteLine("-n или -num [число]  : Задает количество паролей.");
            Console.WriteLine("-l или -len [число]  : Задает длину пароля.");
            Console.WriteLine(); 
            Console.WriteLine("Создайте файл \"no.help\" в папке программы чтобы не видет напоминание о дополнительных функциях.");
            Console.WriteLine("----------------------------------");
        }

        static void GenerateAndDisplayPasswords(int length, int count, int complexity)
        {
            string chars = complexity switch
            {
                1 => "0123456789",
                2 => "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789",
                3 => "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()",
                _ => "0123456789"
            };

            Random random = new();
            for (int i = 0; i < count; i++)
            {
                StringBuilder password = new();
                for (int j = 0; j < length; j++)
                {
                    password.Append(chars[random.Next(chars.Length)]);
                }

                Console.Write(">>>   ", Console.ForegroundColor = ConsoleColor.DarkYellow);
                Console.Write(password.ToString(), Console.ForegroundColor = ConsoleColor.Green);
                Console.WriteLine("   <<<", Console.ForegroundColor = ConsoleColor.DarkYellow);
            }
            Console.ResetColor();
        }
    }
}
