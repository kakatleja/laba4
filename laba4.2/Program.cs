using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4._2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Ввод времени t1 и t2 с проверкой
            Time t1 = Check.ReadTime("Введите время для t1: ");
            Time t2 = Check.ReadTime("Введите время для t2: ");

            // Тестирование конструктора и ToString
            Console.WriteLine($"t1 = {t1}, t2 = {t2}");

            // Тестирование вычитания
            Time diff = t1.Subtract(t2);
            Console.WriteLine($"t1 - t2 = {diff}");

            // Тестирование унарных операций
            Time t3 = t1;
            t3++;
            Console.WriteLine($"t1++ = {t3}");
            t3--;
            t3--;
            Console.WriteLine($"t1-- = {t3}");

            // Тестирование приведения типов
            int minutes = t1;
            Console.WriteLine($"t1 в минутах = {minutes}");
            bool isNonZero = (bool)t1;
            Console.WriteLine($"t1 != 00:00? {isNonZero}");

            // Тестирование бинарных операций
            Console.WriteLine($"t1 < t2? {t1 < t2}");
            Console.WriteLine($"t1 > t2? {t1 > t2}");

            // Проверка перехода через сутки
            Time t4 = new Time(0, 0);
            t4--;
            Console.WriteLine($"00:00-- = {t4}");
            t4++;
            Console.WriteLine($"00:00--++ = {t4}");
        }

    }
    
}
