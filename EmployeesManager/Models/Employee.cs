using System;
using System.ComponentModel;

namespace EmployeesManager.Models
{
    class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _Name;

        private string _SurName;

        private string _Patronymic;

        private string _Department;

        public virtual Departament Departament { get; set; }

        public int Id { get; set; }

        public string Name
        {
            get => _Name;
            set
            {
                _Name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public string SurName
        {
            get => _SurName;
            set
            {
                _SurName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SurName)));
            }
        }

        public string Patronymic
        {
            get => _Patronymic;
            set
            {
                _Patronymic = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Patronymic)));
            }
        }

        public DateTime DayOfBirth { get; set; }

        public string Department
        {
            get => _Department;
            set
            {
                _Department = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Department)));
            }
        }

        public int Age => (int)Math.Floor((DateTime.Now - DayOfBirth).TotalDays / 365);

        public override string ToString() => $"Сотрудник[{Id}]:{SurName}";
    }
}