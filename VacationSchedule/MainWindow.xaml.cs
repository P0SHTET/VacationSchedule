﻿using IPersonLib;
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
        private VacationCalendar _vacationCalendar;
        private DepartmentList _departmentList;
        public MainWindow()
        {
            InitializeComponent();


            _departmentList = JSONConverter<DepartmentList>.Deserialize();

            UpdateCalendar();
            UpdateDepartmentCombo();
            DepartmentCombo.SelectedIndex = 0;
        }

        private void UpdateDepartmentCombo()
        {
            DepartmentCombo.Items.Clear();
            int j = 0;
            foreach (IDepartment department in _departmentList.Departments)
            {
                DepartmentCombo.Items.Insert(j, department.Name);
                j++;
            }
        }

        private void VacationCalendar_InfoChanged()
        {
            SaveInfo();
        }

        private void SaveInfo()
        {
            JSONConverter<DepartmentList>.Serialize(_departmentList);
        }

        private void DepartmentCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCalendar();
        }

        private void UpdateCalendar()
        {
            int selectedDepartment = 0;
            if (_vacationCalendar != null)
            {
                _vacationCalendar.InfoChanged -= VacationCalendar_InfoChanged;
                MainGrid.Children.Remove(_vacationCalendar);
                selectedDepartment = DepartmentCombo.SelectedIndex;
            }
            if (DepartmentCombo.SelectedIndex == -1) selectedDepartment = 0;
            _vacationCalendar = new VacationCalendar(_departmentList.Departments[selectedDepartment])
            {
                Margin = new Thickness(0, 100, 0, 0)
            };
            MainGrid.Children.Add(_vacationCalendar);
            _vacationCalendar.InfoChanged += VacationCalendar_InfoChanged;
        }

        private void RenameDepartment_ButtonClick(object sender, RoutedEventArgs e)
        {
            double xPosition = PointToScreen(new Point(0, DepartmentCombo.ActualHeight)).X + 4;
            double yPosition = PointToScreen(new Point(0, DepartmentCombo.ActualHeight)).Y + 9;

            ChangeDepartmentWindow window = new ChangeDepartmentWindow(false, xPosition, yPosition,
                _departmentList.Departments[DepartmentCombo.SelectedIndex].Name);
            window.ChangeNameDepartment += Window_ChangeNameDepartment;
            window.ShowDialog();
        }

        private void Window_ChangeNameDepartment(string name)
        {
            _departmentList.Departments[DepartmentCombo.SelectedIndex].Name = name;
            int ind = DepartmentCombo.SelectedIndex;
            UpdateDepartmentCombo();
            DepartmentCombo.SelectedIndex = ind;
            SaveInfo();
        }

        private void AddDepartment_ButtonClick(object sender, RoutedEventArgs e)
        {
            double xPosition = PointToScreen(new Point(0, DepartmentCombo.ActualHeight)).X + 4;
            double yPosition = PointToScreen(new Point(0, DepartmentCombo.ActualHeight)).Y + 9;

            ChangeDepartmentWindow window = new ChangeDepartmentWindow(true, xPosition, yPosition);
            window.AddDepartment += Window_AddDepartment;
            window.ShowDialog();
        }

        private void Window_AddDepartment(string name)
        {
            _departmentList.Departments.Add(new Department(name));
            int ind = DepartmentCombo.SelectedIndex;
            UpdateDepartmentCombo();
            DepartmentCombo.SelectedIndex = ind;
            SaveInfo();
        }

        private void DeleteDepartment_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (_departmentList.Departments.Count == 1)
            {
                MessageBox.Show("Это последний существующий отдел, его удаление невозможно.", "Внимание!",
                  MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (MessageBox.Show("Вы действительно хотите удалить отдел " + DepartmentCombo.Text + "?", "Подтвердите действие",
                    MessageBoxButton.YesNo, MessageBoxImage.Question)
                    == MessageBoxResult.Yes)
            {
                _departmentList.Departments.Remove(_departmentList.Departments[DepartmentCombo.SelectedIndex]);
                UpdateDepartmentCombo();
                DepartmentCombo.SelectedIndex = 0;
                SaveInfo();
            }
        }
    }
}
