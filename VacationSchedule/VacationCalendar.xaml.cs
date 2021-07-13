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
    /// Логика взаимодействия для VacationCalendar.xaml
    /// </summary>
        
    public partial class VacationCalendar : UserControl
    {
        int[] PersonDay = new int[365];
        List<SolidColorBrush> RectanglesColors = new List<SolidColorBrush>()
        {
            new SolidColorBrush(new Color() { A = 100, R = 255, G = 0, B = 0 }),
            new SolidColorBrush(new Color() { A = 100, R = 0, G = 255, B = 0 }),
            new SolidColorBrush(new Color() { A = 100, R = 0, G = 0, B = 255 }),
            new SolidColorBrush(new Color() { A = 100, R = 255, G = 255, B = 0 }),
            new SolidColorBrush(new Color() { A = 100, R = 255, G = 0, B = 255 }),
            new SolidColorBrush(new Color() { A = 100, R = 0, G = 255, B = 255 }),
        };
        List<PersonVacation> people = new List<PersonVacation>();
        List<WorkersVacation> vacations = new List<WorkersVacation>();
        public VacationCalendar()
        {
            InitializeComponent();
            List<WorkersVacation> workersVacations = new List<WorkersVacation>();
            for(int i =0; i < 35; i++)
            {
                workersVacations.Add(new WorkersVacation(new PersonVacation()
                {
                    Name = i.ToString(),
                    StartDateVacation = new DateTime(2021, 3, (i + 1) % 28 + 1),
                    EndDateVacation = new DateTime(2021, 4, (i + 1) % 28 + 1),
                }, RectanglesColors[i % RectanglesColors.Count])
                {
                    Margin = new Thickness(0, 1, 2, 1)
                });
            }

            
            foreach(var workers in workersVacations)
                MainStackPanel.Children.Add(workers);

            for(int i = 0; i<365;i++)
            {
                PersonDay[i] = workersVacations.Where(x =>
                      ((TimeSpan)(x.Person.StartDateVacation - new DateTime(2021, 1, 1))).Days <= i + 1 &&
                      ((TimeSpan)(x.Person.EndDateVacation - new DateTime(2021, 1, 1))).Days >= i + 1).Count();
            }

            int x = -10;
            byte a = (byte)x;
            int y = 300;
            byte b = (byte)y;

            LinearGradientBrush gradient = new LinearGradientBrush();

            int CountPerson = workersVacations.Count;

            for(int i = 0; i < 365; i++)
            {
                double percent = PersonDay[i] * 1.0/ CountPerson;
                Color color = new Color()
                {
                    A = 150,
                    R = percent < 0.1 ? (byte)0 : percent > 0.25 ? (byte)255 : (byte)((percent-0.1)*(1/0.25)*255),
                    G = percent < 0.1 ? (byte)255 : percent > 0.25 ? (byte)0 : (byte)(255-(percent - 0.1) * (1 / 0.25) * 255),
                    B = 0
                };
                gradient.GradientStops.Add(new GradientStop(color, i / 365.0));
            }
            ResultRectangle.Fill = gradient;
        }
    }
}
