using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace laba4
{
    internal class z1_5
    {

        // Первое задание
        public static void MoveFirstToEnd<T>(List<T> list)
        {
            // Проверка списка
            if (list == null || list.Count == 0) return;

            T first = list[0];
            list.RemoveAt(0);
            list.Add(first);

        }

        // Второе задание
        public static void RemoveSameNeighborElements<T>(List<T> list)
        {
            // Проверка списка
            if (list == null || list.Count < 2) return;

            int n = list.Count;

            // Создаем словарь для индексов
            var toRemove = new HashSet<int>();

            // Находим индексы которые нужно удалить
            for (int i = 0; i < n; i++)
            {
                T left = list[(i - 1 + n) % n];
                T right = list[(i + 1) % n];
                if (Equals(left, right))
                    toRemove.Add(i);
            }

            // Удаляем индексы
            for (int i = n - 1; i >= 0; i--) // идем с конца, чтобы безопасно удалять
            {
                if (toRemove.Contains(i))
                    list.RemoveAt(i);
            }
        }

        // Третье задание
        public static void AnalyzeFactories(HashSet<string> factories, List<HashSet<string>> buyers)
        {

            // Парочка проверок
            if (factories == null || factories.Count == 0)
            {
                Console.WriteLine("Список фабрик пуст.");
                return;
            }

            if (buyers == null || buyers.Count == 0)
            {
                Console.WriteLine("Нет данных о покупателях.");
                return;
            }

            // Создаем списки для фабрик
            var allBoughtByAll = new List<string>();
            var boughtBySome = new List<string>();
            var boughtByNone = new List<string>();

            // Проходимся по фабрикам
            foreach (var factory in factories)
            {

                // Флаги для проверки
                bool boughtByAllFlag = true;
                bool boughtBySomeFlag = false;

                // Проверяем фабрики у одного покупателя
                foreach (var buyer in buyers)
                {
                    if (buyer.Contains(factory))
                        boughtBySomeFlag = true;
                    else
                        boughtByAllFlag = false;
                }

                // Распределение по группам
                if (boughtByAllFlag)
                    allBoughtByAll.Add(factory);
                else if (boughtBySomeFlag)
                    boughtBySome.Add(factory);
                else
                    boughtByNone.Add(factory);
            }

            Console.WriteLine("\nФабрики, купленные всеми покупателями: " +
                              (allBoughtByAll.Count > 0 ? string.Join(" ", allBoughtByAll) : "-"));
            Console.WriteLine("Фабрики, купленные некоторыми покупателями: " +
                              (boughtBySome.Count > 0 ? string.Join(" ", boughtBySome) : "-"));
            Console.WriteLine("Фабрики, купленные никем: " +
                              (boughtByNone.Count > 0 ? string.Join(" ", boughtByNone) : "-"));

        }


        // === Задача 4 ===
        public static void FindDeafConsonants(string fileName)
        {
            // Проверка
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            string text = File.ReadAllText(fileName);

            // Создаем словарь всех гс
            var deafConsonants = new HashSet<char> { 'п', 'ф', 'к', 'т', 'ш', 'с', 'х', 'ц', 'ч' };

            // Разбиваем текст на слова
            MatchCollection matches = Regex.Matches(text, "\\w+");
            var words = new List<string>();
            foreach (Match m in matches)
                words.Add(m.Value.ToLower()); // Создаем список слов

            // Список подходящих гс
            var result = new List<char>();

            // проходимся по каждой гс из словаря
            foreach (char c in deafConsonants)
            {
                // Флаги для гс
                bool inAllOdd = true;
                bool inAnyEven = false;

                // Цикл по словам
                for (int i = 0; i < words.Count; i++)
                {
                    if (i % 2 == 0) // Ченые слова
                    {
                        if (!words[i].Contains(c))
                        {
                            inAllOdd = false;
                            break;
                        }
                    }
                    else // Четные слова
                    {
                        if (words[i].Contains(c))
                            inAnyEven = true;
                    }
                }

                if (inAllOdd && !inAnyEven)
                    result.Add(c);
            }

            result.Sort();
            Console.WriteLine("Результат: " + (result.Count > 0 ? string.Join(" ", result) : "-"));
        }

        // Пятое задание
        public static void CheapestSourCream(string[] lines)
        {

            // Ключ - жирность, список - цены
            Dictionary<int, List<int>> prices = new Dictionary<int, List<int>>();
            prices[15] = new List<int>();
            prices[20] = new List<int>();
            prices[25] = new List<int>();

            // Проверка на ввод
            foreach (var line in lines)
            {
                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 4)
                {
                    Console.WriteLine($"Ошибка формата строки: {line}");
                    continue;
                }

                if (!int.TryParse(parts[2], out int fat) || !int.TryParse(parts[3], out int price))
                {
                    Console.WriteLine($"Ошибка: неверные числовые данные в строке '{line}'.");
                    continue;
                }

                if (!prices.ContainsKey(fat))
                {
                    Console.WriteLine($"Ошибка: недопустимая жирность {fat} в строке '{line}'.");
                    continue;
                }

                if (price < 2000 || price > 5000)
                {
                    Console.WriteLine($"Ошибка: цена вне диапазона (2000–5000) в строке '{line}'.");
                    continue;
                }

                // Добавляем все цены для каждого ключа
                prices[fat].Add(price);
            }

            // Ищем количество минимальных цен у каждого ключа
            var result = new List<int>();
            foreach (int fat in new[] { 15, 20, 25 })
            {
                if (prices[fat].Count == 0) { result.Add(0); continue; }
                int min = prices[fat].Min();
                result.Add(prices[fat].Count(p => p == min));
            }

            Console.WriteLine("Количество магазинов с минимальной ценой: " + string.Join(" ", result));
        }
    }
}
