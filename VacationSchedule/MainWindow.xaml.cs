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
        public MainWindow()
        {
            InitializeComponent();
            //WorkersVacation workers = new WorkersVacation(new PersonVacation()
            //{
            //    Name = "Алексей",
            //    StartDateVacation = new DateTime(2021, 3, 5),
            //    EndDateVacation = new DateTime(2021, 4, 5),
            //}, new SolidColorBrush(new Color() { A = 100, R = 0, G = 255, B = 0 }));
            //workers.Margin = new Thickness(200, 100, 100, 736);
            //MainGrid.Children.Add(workers);
        }       
    }
}
