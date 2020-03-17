using EmployeesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Data
{
    static class TestData
    {
        public static List<Employee> Employees { get; } = Enumerable.Range(1, 100)
            .Select(i => new Employee
            {
                Id = i,
                Name = $"Имя {i}",
                SurName = $"Фамилия {i}",
                Patronymic = $"Отчество {i}",
                DayOfBirth = DateTime.Now.Subtract(TimeSpan.FromDays(365/6 * (i * 18)))
            })
            .ToList();
        private static void TakeEmployees()
        {
            using (var db = new DataContext())
            {
                var rnd = new Random();
                var dep_id = rnd.Next(1, 10);

                var dep = db.Departaments.Include("Employees").FirstOrDefault(d => d.ID == dep_id);
                if (dep is null) return;

                var employees = dep.Employees;
             
            }
        }
        private static void TakeDepartament()
        {
            using (var db = new DataContext())
            {
                db.Database.Log = str => Console.WriteLine(">>>>{0}", str);
                if (db.Departaments.Any())
                {
                    foreach (var dep in Enumerable.Range(1, 10).Select(i => new Departament { Name = $"Отдел: {i}" }))
                        db.Departaments.Add(dep);
                    db.SaveChanges();
                }

                if (!db.Employees.Any())
                {
                    var rnd = new Random();
                    foreach (var employee in Enumerable.Range(1, 100).Select(i => new Employee
                    {
                        Name = $"Сотрудник {i}",
                        DayOfBirth = DateTime.Now.Subtract(TimeSpan.FromDays(365 * rnd.Next(18, 30))),

                    }))
                    {
                        var dep_id = rnd.Next(1, 10);
                        employee.Departament = db.Departaments.FirstOrDefault(d => d.ID == dep_id);
                        db.Employees.Add(employee);
                    }
                    db.SaveChanges();
                }
            }
        }
    }
}
