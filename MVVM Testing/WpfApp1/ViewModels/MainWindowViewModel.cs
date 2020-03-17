using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using WpfApp1.Infrastructrure.Commands;
using WpfApp1.ViewModels.Base;

namespace WpfApp1.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string _Title = "Заголовок окна проекта MVVM";
        public string Title
        {
            get => _Title;
            //set
            //{
            //    if (Equals(_Title, value)) return false;
            //    _Title = value;
            //    OnPropertyChanged(nameof(Title));
            //}
            set => Set(ref _Title, value);
        }
        private ObservableCollection<EmployeeViewModel> _Employees = new ObservableCollection<EmployeeViewModel>();

        public ObservableCollection<DepartamentViewModel> _Departaments;

        public ObservableCollection<DepartamentViewModel> Departaments
        {
            get => _Departaments;
            set => Set(ref _Departaments, value);
        }

        public ObservableCollection<EmployeeViewModel> Employees
        {
            get => _Employees;
            set => Set(ref _Employees, value);
        }
        private EmployeeViewModel _SelectedEmployee;
        public EmployeeViewModel SelectedEmployee
        {
            get => _SelectedEmployee;
            set => Set(ref _SelectedEmployee, value);
        }

        #region Команды

        public ICommand CreateNewEmployeeCommand { get; }

        public ICommand RemoveEmployeeCommand { get; }

        private void CreateNewEmployeeCommandExecutes(object parameter)
        {
            var new_employe = new EmployeeViewModel
            {
                Name = "NewEmployeName"
            };
            _Employees.Insert(0, new_employe);
            SelectedEmployee = new_employe;
        }

        public ICommand RemoveEmployeesCommand { get; }

        private void OnRemoveEmployeesCommand(object parameter)
        {
            if (!(parameter is EmployeeViewModel employee)) return;
            _Employees.Remove(employee);
            if (ReferenceEquals(_SelectedEmployee, employee))
                SelectedEmployee = null;
        }
        private bool CanRemoveEmployeeCommandExecute(object parameter) => parameter is EmployeeViewModel;
        #endregion
        public MainWindowViewModel()
        {
            var rnd = new Random();
            foreach (var employee in Enumerable.Range(1, 100).Select(i => new EmployeeViewModel
            {
                Name = $"Имя {i}",
                SurName = $"Фамилия {i}",
                Patronymic = $"Отчество {i}",
                BirthDay = DateTime.Now.Subtract(TimeSpan.FromDays(365 * rnd.Next(18, 50)))
            }))
                _Employees.Add(employee);

            _Departaments = new ObservableCollection<DepartamentViewModel>(
                Enumerable.Range(1, 10).Select(i => new DepartamentViewModel { Name = $"Отдел {i}" }));

            #region Команды

            CreateNewEmployeeCommand = new LambdaCommand(CreateNewEmployeeCommandExecutes);

            RemoveEmployeeCommand = new LambdaCommand(OnRemoveEmployeesCommand, CanRemoveEmployeeCommandExecute);

            #endregion
        }


    }
}
