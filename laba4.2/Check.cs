using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4._2
{
    internal class Check
    {
        // Метод для безопасного ввода времени с консоли
        public static Time ReadTime(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || !input.Contains(":"))
                {
                    Console.WriteLine("Ошибка: формат должен быть ЧЧ:ММ.");
                    continue;
                }

                string[] parts = input.Split(':');
                if (parts.Length != 2)
                {
                    Console.WriteLine("Ошибка: формат должен быть ЧЧ:ММ.");
                    continue;
                }

                if (!byte.TryParse(parts[0], out byte hours) || hours > 23)
                {
                    Console.WriteLine("Ошибка: часы должны быть от 0 до 23.");
                    continue;
                }

                if (!byte.TryParse(parts[1], out byte minutes) || minutes > 59)
                {
                    Console.WriteLine("Ошибка: минуты должны быть от 0 до 59.");
                    continue;
                }

                return new Time(hours, minutes);
            }
        }
    }
}
