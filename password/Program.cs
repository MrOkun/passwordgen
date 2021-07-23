using System;
using System.Windows.Forms;

namespace password
{
    class Program
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        {
            Random rnd = new Random();

            string abc = "QqWwEeRrTtYyUuIiOoPpAaSsDdFfGgHhJjKkLlZzXxCcVvBbNnMm1234567890";
            string spec = "$%&";
            string num = "123456789";
            char[] alph = abc.ToCharArray();
            char[] specAlph = spec.ToCharArray();
            char[] numAlph = num.ToCharArray();

            string password = null;

            length:
            Console.Write("Введите длину пароля -->");
            int length = int.Parse(Console.ReadLine());

            if (length > 0)
            {
                for (int i = 0; i < length - 2; i++)
                {
                    int value = rnd.Next(0, alph.Length);
                    password += alph[value];
                }

                int specValue = rnd.Next(0, specAlph.Length);
                int numValue = rnd.Next(0, numAlph.Length);
                password += specAlph[specValue]; //спец символ.
                password += numAlph[numValue]; //цифра.
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Вы ввели не корректную длину пароля!");
                Console.ResetColor();
                goto length;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(password + "- был скопирован в буфер обмена.");
            Clipboard.SetText(password);

            Console.ReadLine();
        }
    }
}
