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
using PersonVacationLib;

namespace VacationSchedule
{
    /// <summary>
    /// Логика взаимодействия для WorkersVacation.xaml
    /// </summary>
    public partial class WorkersVacation : UserControl
    {
        public Thickness RectangleMargin { get; set; }
        public SolidColorBrush RectangleFill { get; set; }
        private PersonVacation Person;
        public WorkersVacation(PersonVacation person)
        {
            Person = person;
            InitializeComponent();
            RectangleFill = Brushes.Red;
            double left;
            double right;
            
            left = ((TimeSpan)(Person.StartDateVacation - new DateTime(2021,1,1))).Days/365.0 * 800;
            right = 800- left - ((TimeSpan)(Person.EndDateVacation - Person.StartDateVacation)).Days / 365.0 * 800;
            RectangleMargin = new Thickness(left, 0, right, 0);

        }
    }
}
