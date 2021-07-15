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
using System.Windows.Navigation;
using System.Windows.Shapes;
using IPersonLib;
using PersonVacationLib;

namespace VacationSchedule
{
    /// <summary>
    /// Логика взаимодействия для VacationCalendar.xaml
    /// </summary>
        
    public partial class VacationCalendar : UserControl
    {
        private int[] _personDay = new int[365];
        readonly List<SolidColorBrush> RectanglesColors = new()
        {
            new SolidColorBrush(new Color() { A = 100, R = 255, G = 0, B = 0 }),
            new SolidColorBrush(new Color() { A = 100, R = 0, G = 255, B = 0 }),
            new SolidColorBrush(new Color() { A = 100, R = 0, G = 0, B = 255 }),
            new SolidColorBrush(new Color() { A = 100, R = 255, G = 255, B = 0 }),
            new SolidColorBrush(new Color() { A = 100, R = 255, G = 0, B = 255 }),
            new SolidColorBrush(new Color() { A = 100, R = 0, G = 255, B = 255 }),
        };
        private List<WorkersVacation> _vacations = new();

        private IDepartment _department;

        public delegate void UpdateInfo();
        public event UpdateInfo InfoChanged;

        public VacationCalendar(IDepartment department)
        {
            _department = department;
            InitializeComponent();
            UpdateCalendar();
            UpdateResultRectangle();
        }

        private void UpdateCalendar()
        {
            foreach (var workers in _vacations)
            {
                MainStackPanel.Children.Remove(workers);
                workers.DatesChange -= Workers_DatesChange;
                workers.DeletePersonEvent -= Workers_DeletePersonEvent;
            }
            _vacations.Clear();
            int j = 0;
            foreach (IPersonVacation person in _department.PersonVacations)
            {
                _vacations.Add(new WorkersVacation(person, RectanglesColors[j % RectanglesColors.Count])
                { Margin = new Thickness(0, 1, 2, 1) });
                j++;
            }
            foreach (var workers in _vacations)
            {
                MainStackPanel.Children.Add(workers);
                workers.DatesChange += Workers_DatesChange;
                workers.DeletePersonEvent += Workers_DeletePersonEvent;
            }
        }

        private void Workers_DeletePersonEvent(IPersonVacation person)
        {
            _department.PersonVacations.Remove(person);
            UpdateCalendar();
            UpdateResultRectangle();
            InfoChanged?.Invoke();
        }

        private void Workers_DatesChange()
        {
            UpdateResultRectangle();
            InfoChanged?.Invoke();
        }

        private void UpdateResultRectangle()
        {
            for (int i = 0; i < 365; i++)
            {
                _personDay[i] = _vacations.Where(x => (x.Person.StartDateVacation != null && x.Person.EndDateVacation != null) &&
                      ((TimeSpan)(x.Person.StartDateVacation - new DateTime(2021, 1, 1))).Days <= i + 1 &&
                      ((TimeSpan)(x.Person.EndDateVacation - new DateTime(2021, 1, 1))).Days >= i + 1).Count();
            }

            LinearGradientBrush gradient = new();

            int CountPerson = _vacations.Count;

            for (int i = 0; i < 365; i++)
            {
                double percent = _personDay[i] * 1.0 / CountPerson;
                Color color = new()
                {
                    A = 150,
                    R = percent == 0 ? (byte)255 : percent < 0.1 || _personDay[i] == 1 ? (byte)0 : percent > 0.25 ? (byte)255 : (byte)((percent - 0.1) * (1 / 0.25) * 255),
                    G = percent == 0 ? (byte)255 : percent < 0.1 || _personDay[i] == 1 ? (byte)255 : percent > 0.25 ? (byte)0 : (byte)(255 - (percent - 0.1) * (1 / 0.25) * 255),
                    B = percent == 0 ? (byte)255 : (byte)0
                };
                gradient.GradientStops.Add(new GradientStop(color, i / 365.0));
            }
            ResultRectangle.Fill = gradient;
        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            double xPosition = PointToScreen(new Point(0, AddPersonBut.ActualHeight)).X + 400;
            double yPosition = PointToScreen(new Point(0, AddPersonBut.ActualHeight)).Y - 80;
            ChangeDateWindow window = new ChangeDateWindow(xPosition, yPosition, new PersonVacation(), true);

            window.AddPersonEvent += Window_AddPersonEvent;
            window.ShowDialog();

        }

        private void Window_AddPersonEvent(IPersonVacation person)
        {
            _department.PersonVacations.Add(person);
            UpdateCalendar();
            UpdateResultRectangle();
            InfoChanged?.Invoke();
        }
    }
}
