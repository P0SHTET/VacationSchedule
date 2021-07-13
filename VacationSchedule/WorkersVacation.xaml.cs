using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace VacationSchedule
{
    /// <summary>
    /// Логика взаимодействия для WorkersVacation.xaml
    /// </summary>
    public partial class WorkersVacation : UserControl, INotifyPropertyChanged
    {
        private Thickness _rectangleMargin;
        public Thickness RectangleMargin 
        {
            get
            {
                return _rectangleMargin;
            }
            set
            {
                _rectangleMargin = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RectangleMargin)));
            }
        }
        private SolidColorBrush _rectangleFill;
        public SolidColorBrush RectangleFill
        {
            get
            {
                return _rectangleFill;
            }
            set
            {
                _rectangleFill = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RectangleFill)));
            }
        }
        private IPersonVacation Person;

        public event PropertyChangedEventHandler PropertyChanged;

        public WorkersVacation()
        {
            InitializeComponent();
        }
        public WorkersVacation(IPersonVacation person, SolidColorBrush fill)
        {
            Person = person;
            
            InitializeComponent();
            NameBlock.Text =" " + Person.Name;
            DataContext = this;
            DataRec.Fill = fill;
            UpdateDates();
        }
        private void UpdateDates()
        {
            double left;
            double right;

            left = ((TimeSpan)(Person.StartDateVacation - new DateTime(2021, 1, 1))).Days / 365.0 * 1417;
            right = ((TimeSpan)(new DateTime(2021, 12, 31)-Person.EndDateVacation)).Days / 365.0 * 1417;
            RectangleMargin = new Thickness(left, 0, right, 0);
        }

        private void NameBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            double xPosition = PointToScreen(new Point(0,((TextBlock)sender).ActualHeight)).X;
            double yPosition = PointToScreen(new Point(0, ((TextBlock)sender).ActualHeight)).Y;
            ChangeDateWindow changeDateWindow = new ChangeDateWindow(xPosition, yPosition, Person);
            //var r = MainGrid.ActualWidth;
            changeDateWindow.ChangeDateEvent += ChangeDateWindow_ChangeDateEvent;
            changeDateWindow.ShowDialog();
        }

        private void ChangeDateWindow_ChangeDateEvent(DateTime startVacation, DateTime endVacation)
        {
            Person.StartDateVacation = startVacation;
            Person.EndDateVacation = endVacation;

            UpdateDates();
        }
    }
}
