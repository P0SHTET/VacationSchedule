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
            _vacationCalendar = new VacationCalendar(_departmentList.Departments[1])
            {
                Margin = new Thickness(150, 100, 0, 0)
            };
            MainGrid.Children.Add(_vacationCalendar);
            _vacationCalendar.InfoChanged += VacationCalendar_InfoChanged;
        }

        private void VacationCalendar_InfoChanged()
        {
            JSONConverter<DepartmentList>.Serialize(_departmentList);
        }
    }
}
