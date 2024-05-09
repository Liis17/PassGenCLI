namespace PassGen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var value = 1;
            var stringpass = "";
            var inparam = "";
            var outputpass = true;
            foreach (string arg in args)
            {
                inparam += arg;
            }
            if (inparam == "")
            {

            }
            else if (inparam.Contains("-d1") || inparam.Contains("-d2") || inparam.Contains("-d3") || inparam.Contains("-dif1") || inparam.Contains("-dif2") || inparam.Contains("-dif3"))
            {
                var param = inparam.Replace("-d", "").Replace("-dif", "");

                try
                {
                    value = int.Parse(param);
                }
                catch
                {
                    Console.WriteLine("Неизвестный параметр для -d | -dif", Console.ForegroundColor = ConsoleColor.Red);
                    outputpass = false;
                }
            }
            else if (inparam.Contains("-h") || inparam.Contains("-help"))
            {
                Console.WriteLine("-------------ПОМОЩЬ-------------", Console.ForegroundColor = ConsoleColor.DarkRed);
                Console.WriteLine("-d [значение] | -dif [значение] - сложность, входное значение от 1 до 3, 1 по умолчанию", Console.ForegroundColor = ConsoleColor.White);
                Console.WriteLine("-h | -help - помощь", Console.ForegroundColor = ConsoleColor.White);
                Console.WriteLine("--------------------------------", Console.ForegroundColor = ConsoleColor.DarkRed);
                outputpass = false;
            }
            else
            {
                Console.WriteLine("Неизвестный параметр запуска", Console.ForegroundColor = ConsoleColor.Red);
                outputpass = false;
            }
            for (int i = 0; i < value; i++)
            {
                stringpass += Guid.NewGuid().ToString("N");
            }
            if (outputpass)
            {
                Console.Write(">>>   ", Console.ForegroundColor = ConsoleColor.DarkYellow);
                Console.Write(stringpass, Console.ForegroundColor = ConsoleColor.Green);
                Console.Write("   <<<", Console.ForegroundColor = ConsoleColor.DarkYellow);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
