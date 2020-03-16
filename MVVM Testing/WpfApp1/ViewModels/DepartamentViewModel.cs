using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModels.Base;

namespace WpfApp1.ViewModels
{
    class DepartamentViewModel : ViewModel
    {
        private string _Name;

        public string Name { get => _Name; set => Set(ref _Name, value); }
    }
}
