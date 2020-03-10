using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.Extensions;

namespace TestConsole
{
    internal static class StudentsTests
    {
        public static void Run()
        {
            const string student_names_file = "Names.txt";

            var file_with_names = new FileInfo(student_names_file);

            var rnd = new Random();
            var dekanat = new Dekanat();

            for (var i = 0; i < 10; i++)
                dekanat.Add(new StudentsGroup { Name = $"Группа {i + 1}" });
            foreach(var line in file_with_names.GetLines())
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var components = line.Split(' ');
                if (components.Length < 3) continue;

                var student = new Student
                {
                    LastName = components[0],
                    FirstName = components[1],
                    Patronymic = components[2],
                    Ratings = rnd.GetRandomIntValues(20, 3, 5).ToList()
                };
                dekanat.Add(student);
            }
            //IEnumerable<Student> students_enum = dekanat;
            //IQueryable<Student> student_query = students_enum.AsQueryable();

            //foreach(var i in Enumerable.Range(0, 100))
            //{

            //}
            //for(var i = 0; i < 100; i++)
            //{

            //}

            //var simple_students = Enumerable.Range(1, 100)
            //    .Select(i => new Student { FirstName = $"Student {i}" });


            //foreach (var student in simple_students)
            //    Console.WriteLine(student);

            var best_students = dekanat.Where(student => student.AverageRating >= 4);

            var last_students = dekanat.Where(student => student.AverageRating < 4);


            foreach (var best_student in best_students)
                Console.WriteLine(best_students);
            foreach (var last_student in last_students)
                Console.WriteLine(best_students);

            var best_count = best_students.Count();
            var last_count = last_students.Count();

            var names_lengths = file_with_names.GetLines()
                .Select(str => str.Split(' '))
                .Select(strs => new KeyValuePair<string, int>(strs[1], strs[1].Length))
                .Where(v =>v.Value > 4)
                .OrderBy(v => v.Value)
                .ToArray();
        }
    }
}
