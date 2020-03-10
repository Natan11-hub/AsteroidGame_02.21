using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public delegate double Fun(double x);
    static class Program
    {
        static void Main(string[] args)
        {
            var numbers_count = 100;
            var max_value = 51;
            var rnd = new Random();
            var numbers = new List<int>();
            for (var i = 0; i < numbers_count; i++)
                numbers.Add(rnd.Next(0, 51));

            var numbers_counts = new Dictionary<int, int>();
            var numbers_counts2 = new int[max_value];
            for (var i = 0; i < max_value; i++)
                numbers_counts[i] = 0;

            for (var i = 0; i < numbers_count; i++)
            {
                var n = numbers[i];
                #region Реализация с помощью словаря
                if (numbers_counts.ContainsKey(n))
                    numbers_counts[n]++;
                else
                    numbers_counts.Add(n, 1);
                #endregion
                #region Реализация с помощью словаря

                numbers_counts2[n]++;
                #endregion

            }
            var counts3 = GetItemCounts(numbers);

            string GetGroupKey(int n)
            {
                return n.ToString("0000");
            }

            var counts4 = numbers.GroupBy(n => n)
                .Select(group => new { value = group.Key, count = group.Count() })
                .OrderBy(v => v.value)
                .ToArray();
            var counts5 = numbers.GroupBy(n => n)
                .ToDictionary(group => group.Key, group => group.Count() );
        }
        private static Dictionary<T, int> GetItemCounts<T>(IEnumerable<T> items)
        {
            var result = new Dictionary<T, int>();
            foreach(var item in items)
            {
                if (result.ContainsKey(item))
                    result[item]++;
                else
                    result.Add(item, 1);

                return result;
            }
        }
    }
}