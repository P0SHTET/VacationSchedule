using System;
using System.Collections.Generic;
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

namespace VacationSchedule
{
    /// <summary>
    /// Логика взаимодействия для ChangeDepartmentWindow.xaml
    /// </summary>
    public partial class ChangeDepartmentWindow : Window
    {
        public delegate void ChangeDepartment(string name);
        public event ChangeDepartment ChangeNameDepartment;
        public event ChangeDepartment AddDepartment;

        private bool _newDepartment;
        public ChangeDepartmentWindow(bool newDepartment, double xPosition, double yPosition, string oldName = "")
        {

            InitializeComponent();
            Left = xPosition;
            Top = yPosition;
            _newDepartment = newDepartment;
            NameBox.Text = oldName;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_newDepartment) AddDepartment?.Invoke(NameBox.Text);
            else ChangeNameDepartment?.Invoke(NameBox.Text);
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
