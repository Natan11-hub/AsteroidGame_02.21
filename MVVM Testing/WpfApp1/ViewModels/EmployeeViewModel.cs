using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModels.Base;

namespace WpfApp1.ViewModels
{
    class EmployeeViewModel : ViewModel
    {
        public string _Name;

        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        public string _SurName;

        public string SurName
        {
            get => _SurName;
            set => Set(ref _SurName, value);
        }
        public string _Patronymic;

        public string Patronymic
        {
            get => _Patronymic;
            set => Set(ref _Patronymic, value);
        }
        public DateTime _BirthDay;

        public DateTime BirthDay
        {
            get => _BirthDay;
            set
            {
                if (Set(ref _BirthDay, value))
                    OnPropertyChanged(nameof(Age));
            }
        }

        public int Age => (int)Math.Floor((DateTime.Now - BirthDay).TotalDays / 365);

        private DepartamentViewModel _Departament;

        public DepartamentViewModel Departament
        {
            get => _Departament;
            set => Set(ref _Departament, value);
        }
    }
}
