using IPersonLib;
using System;
using System.Windows;
using PersonVacationLib;

namespace VacationSchedule
{
    /// <summary>
    /// Логика взаимодействия для ChangeDateWindow.xaml
    /// </summary>
    public partial class ChangeDateWindow : Window
    {
        public delegate void ChangeDate(DateTime? startVacation, DateTime? endVacation, string name);
        public delegate void DeletePerson();
        public delegate void AddPerson(IPersonVacation person);
        public event ChangeDate ChangeDateEvent;
        public event DeletePerson DeletePersonEvent;
        public event AddPerson AddPersonEvent;
        private bool _add;
        public ChangeDateWindow(double xPosition, double yPosition, IPersonVacation person, bool add = false)
        {
            
            InitializeComponent();
            _add = add;
            if (_add) DelPersonBut.Visibility = Visibility.Hidden;
            Start.SelectedDate = person.StartDateVacation;
            End.SelectedDate = person.EndDateVacation;
            NameBox.Text = person.Name;
            Left = xPosition;
            Top = yPosition;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text.Length == 0)
            {
                MessageBox.Show("Введите имя сотрудника!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (_add) AddPersonEvent?.Invoke(new PersonVacation(NameBox.Text)
            {
                StartDateVacation = Start.SelectedDate,
                EndDateVacation = End.SelectedDate,
            });
            else ChangeDateEvent?.Invoke(Start.SelectedDate, End.SelectedDate, NameBox.Text);
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
