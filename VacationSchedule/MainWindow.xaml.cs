using IPersonLib;
using JSONUtil;
using PersonVacationLib;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VacationSchedule
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VacationCalendar _vacationCalendar;
        private DepartmentList _departmentList;
        public MainWindow()
        {
            InitializeComponent();


            _departmentList = JSONConverter<DepartmentList>.Deserialize();

            UpdateCalendar();
            UpdateDepartmentCombo();
            DepartmentCombo.SelectedIndex = 0;
        }

        private void UpdateDepartmentCombo()
        {
            DepartmentCombo.Items.Clear();
            int j = 0;
            foreach (IDepartment department in _departmentList.Departments)
            {
                DepartmentCombo.Items.Insert(j, department.Name);
                j++;
            }
        }

        private void VacationCalendar_InfoChanged()
        {
            JSONConverter<DepartmentList>.Serialize(_departmentList);
        }

        private void DepartmentCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCalendar();
        }

        private void UpdateCalendar()
        {
            int selectedDepartment = 0;
            if (_vacationCalendar != null)
            {
                _vacationCalendar.InfoChanged -= VacationCalendar_InfoChanged;
                MainGrid.Children.Remove(_vacationCalendar);
                selectedDepartment = DepartmentCombo.SelectedIndex;
            }
            _vacationCalendar = new VacationCalendar(_departmentList.Departments[selectedDepartment])
            {
                Margin = new Thickness(0, 100, 0, 0)
            };
            MainGrid.Children.Add(_vacationCalendar);
            _vacationCalendar.InfoChanged += VacationCalendar_InfoChanged;
        }

        private void RenameDepartment_ButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void AddDepartment_ButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteDepartment_ButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
