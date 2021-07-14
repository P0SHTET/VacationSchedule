﻿using System;
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
        public delegate void ChangeDate(DateTime? startVacation, DateTime? endVacation);
        public event ChangeDate ChangeDateEvent;
        public ChangeDateWindow(double xPosition, double yPosition, IPersonVacation person)
        {
            
            InitializeComponent();

            Start.SelectedDate = person.StartDateVacation;
            End.SelectedDate = person.EndDateVacation;
            Left = xPosition;
            Top = yPosition;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChangeDateEvent?.Invoke(Start.SelectedDate, End.SelectedDate);
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
