using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestWPAApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindowForHomeWork.xaml
    /// </summary>
    public partial class MainWindowForHomeWork : Window
    {
        public MainWindowForHomeWork()
        {
            InitializeComponent();
            FillList();          
        }
        ObservableCollection<Employee> items = new ObservableCollection<Employee>();
        
        void FillList()
        {
            items.Add(new Employee() { Id = 1, Name = "Vasya", Age = 22, Salary = 3000, Department = "Frontend" });
            items.Add(new Employee() { Id = 2, Name = "Petya", Age = 25, Salary = 6000, Department = "Backend" });
            items.Add(new Employee() { Id = 3, Name = "Kolya", Age = 23, Salary = 8000, Department = "Tester"  });
            lbEmployee.ItemsSource = items;
        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
        }


        private void lbEmployee_Selected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(e.Source.ToString());
        }

        private void lbEmployee_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            MessageBox.Show(e.AddedItems[0].ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            items.Add(new Employee() {
                Id = Convert.ToInt32(TextID.Text),
                Name = TextName.Text,
                Age = Convert.ToInt32(TextAge.Text),
                Salary = Convert.ToInt32(TextSalary.Text),
                Department = TextDepartment.Text});
            Clear();
            
            
        }
        public void Clear()
        {
            TextName = null;
            TextID.Text = null;
            TextSalary = null;
            TextAge = null;
            TextDepartment = null;
        }
    }

    public class Employee
    {
        public string Department { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public override string ToString()
        {
            return $"{Id}\t{Name}\t{Age}\t{Salary}\t{Department}";
        }
    }
}
