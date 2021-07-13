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

        }
    }
}
