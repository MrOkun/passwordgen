using System;
using TextCopy;

namespace password
{
    class Program
    {
        static void Main(string[] args)
        {
            int passwordLength;
            string _password = "";

            string abc = "QqWwEeRrTtYyUuIiOoPpAaSsDdFfGgHhJjKkLlZzXxCcVvBbNnMm1234567890";
            string spec = "$";
            string num = "123456789";
            char[] alph = abc.ToCharArray();
            char[] specAlph = spec.ToCharArray();
            char[] numAlph = num.ToCharArray();

            var rnd = new Random();

            lenght:
            try
            {
                Console.WriteLine("Windows Password Generator [v2.0]");
                Console.Write("Введите длинну пароля ---->  ");
                passwordLength = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вы ввели не корректное значени!");
                Console.ResetColor();
                goto lenght;
            }

            Console.Write($"Установленная длина пароля - ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(passwordLength);
            Console.ResetColor();

            for (int i = 0; i < passwordLength - 2; i++)
            {
                int value = rnd.Next(0, alph.Length);
                _password += alph[value];
            }

            int specValue = rnd.Next(0, specAlph.Length);
            int numValue = rnd.Next(0, numAlph.Length);
            _password += specAlph[specValue]; //спец символ.
            _password += numAlph[numValue]; //цифра.
            Console.WriteLine("Password - " + _password);
            ClipboardService.SetText(_password);
            Console.ReadLine();
    }
    }
}
