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
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            double xPosition = ((TextBlock)sender).Margin.Left + Left;
            double yPosition = ((TextBlock)sender).Margin.Top + Top + 50;
            ChangeDateWindow changeDateWindow = new ChangeDateWindow(xPosition, yPosition);
            changeDateWindow.ChangeDateEvent += ChangeDateWindow_changeDate;
            changeDateWindow.ShowDialog();
        }

        private void ChangeDateWindow_changeDate(DateTime startVacation, DateTime endVacation)
        {
            
        }
    }
}
