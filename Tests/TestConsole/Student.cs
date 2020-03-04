using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Student : IComparable<Student>
    {

        public string Name { get; set; }

        public List<int> Ratings { get; set; } = new List<int>();

        public double AverageRating
        {
            get
            {
                var ratings = Ratings;
                if (ratings == null)
                    throw new InvalidOperationException("Невозможно расчитать среднюю оценку. Список оценок не задан.");
                if (ratings.Count == 0)
                    return double.NaN;

                var sum = 0d;
                for (var i = 0; i < ratings.Count; i++)
                    sum += ratings[i];
                return sum / (double)ratings.Count;
            }
        }
        public override string ToString() => $"{Name} : {AverageRating:0.##}";
        public int CompareTo(object obj)
        {
            var other_student = (Student)obj;
            var current_average_rating = AverageRating;
            var other_average_rating = other_student.AverageRating;

            if (Math.Abs(current_average_rating - other_average_rating) < 0.001)
                return 0;
            if (current_average_rating > other_average_rating)
                return +1;
            else
                return -1;
        }

        public int CompareTo(Student other)
        {
            throw new NotImplementedException();
        }
    }
}
