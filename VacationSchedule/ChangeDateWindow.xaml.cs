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
using IPersonLib;

namespace VacationSchedule
{
    /// <summary>
    /// Логика взаимодействия для ChangeDateWindow.xaml
    /// </summary>
    public partial class ChangeDateWindow : Window
    {
        public delegate void ChangeDate(DateTime? startVacation, DateTime? endVacation, string name);
        public delegate void DeletePerson();
        public event ChangeDate ChangeDateEvent;
        public event DeletePerson DeletePersonEvent;

        public ChangeDateWindow(double xPosition, double yPosition, IPersonVacation person)
        {
            
            InitializeComponent();

            Start.SelectedDate = person.StartDateVacation;
            End.SelectedDate = person.EndDateVacation;
            NameBox.Text = person.Name;
            Left = xPosition;
            Top = yPosition;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeDateEvent?.Invoke(Start.SelectedDate, End.SelectedDate, NameBox.Text);
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить сотрудника " + NameBox.Text + "?", "Подтвердите действие",
                                MessageBoxButton.YesNo, MessageBoxImage.Question) 
                                == MessageBoxResult.Yes)
            {
                DeletePersonEvent?.Invoke();
                DialogResult = false;
            }
        }
    }
}
