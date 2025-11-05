using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4
{
    internal class Program
    {
        static void Main()
        {
            // Вводим номер задания
            Console.Write("Введите номер задания: ");
            string n = Console.ReadLine();

            switch (n)
            {
                case "1":
                    // Вводим элементы списка
                    Console.WriteLine("\nВведите элементы списка через пробел:");
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Список не может быть пустым.");
                        break;
                    }
                    List<string> list = new List<string>(input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

                    // Решение
                    z1_5.MoveFirstToEnd(list);

                    // Вывод
                    Console.WriteLine("Результат: " + string.Join(" ", list));
                    break;
                    
                case "2":

                    // Вводим элементы списка
                    Console.WriteLine("\nВведите элементы списка через пробел (не менее двух):");
                    string input2 = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input2))
                    {
                        Console.WriteLine("Список не может быть пустым.");
                        break;
                    }
                    List<string> list2 = new List<string>(input2.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                    if (list2.Count < 2)
                    {
                        Console.WriteLine("Ошибка: список должен содержать как минимум 2 элемента.");
                        break;
                    }

                    // Вводим элементы для списка
                    z1_5.RemoveSameNeighborElements(list2);

                    // Вывод
                    Console.WriteLine("Результат: " + string.Join(" ", list2));
                    break;

                case "3":

                    // Вводим все фабрики магазина
                    Console.WriteLine("Введите все фабрики магазина через пробел:");
                    string factoriesLine = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(factoriesLine))
                    {
                        Console.WriteLine("Ошибка: список фабрик не может быть пустым.");
                        return;
                    }
                    var factories = new HashSet<string>(factoriesLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

                    // Вводим количество покупателей
                    Console.Write("\nВведите количество покупателей n: ");
                    if (!int.TryParse(Console.ReadLine(), out int nBuyers) || nBuyers <= 0)
                    {
                        Console.WriteLine("Ошибка: введите положительное число.");
                        return;
                    }

                    // Вводим покупки каждого покупателя
                    var buyers = new List<HashSet<string>>();
                    for (int i = 0; i < nBuyers; i++)
                    {
                        Console.WriteLine($"\nВведите фабрики, продукцию которых купил покупатель {i + 1}, через пробел:");
                        string line = Console.ReadLine();
                        buyers.Add(new HashSet<string>(line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)));
                    }

                    // Решение
                    z1_5.AnalyzeFactories(factories, buyers);
                    break;

                case "4":

                    // Файл
                    Console.Write("Введите имя файла: ");
                    string fileName = Console.ReadLine();

                    //Решение
                    z1_5.FindDeafConsonants(fileName);
                    break;

                case "5":
                    {

                        // Вводим кол-во магазинов
                        Console.Write("\nВведите количество магазинов N: ");
                        if (!int.TryParse(Console.ReadLine(), out int nStores) || nStores <= 0)
                        {
                            Console.WriteLine("Ошибка: введите положительное число.");
                            break;
                        }

                        // Вводим данные о магазинах
                        var lines = new List<string>();
                        Console.WriteLine("Введите данные о магазинах в формате: <Фирма> <Улица> <Жирность> <Цена>");
                        for (int i = 0; i < nStores; i++)
                        {
                            Console.Write($"Магазин {i + 1}: ");
                            string line = Console.ReadLine();
                            lines.Add(line);
                        }

                        // Решение
                        z1_5.CheapestSourCream(lines.ToArray());
                        break;
                    }

                default:
                    Console.WriteLine("Очибка");
                    break;

            }

        }
    }
}
