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
using UniversityLibrary;

namespace UniversityUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private University university = new University();

        public MainWindow()
        {
            InitializeComponent();
            comboboxGender.Items.Add(Gender.F);
            comboboxGender.Items.Add(Gender.M);
            university.AddStudent("Ionescu", "Adrian", new DateTime(1999, 10, 10), Gender.M);
            university.AddStudent("Popescu", "Ion", new DateTime(1990, 11, 12), Gender.M);
            university.AddStudent("Pop", "Vasile", new DateTime(1999, 9, 9), Gender.M);
            university.AddStudent("Calin", "Gheorghe", new DateTime(1999, 12, 13), Gender.M);
            LoadStudents();
        }

        private void LoadStudents()
        {

            List<Student> students = university.GetAllStudents();
            listBoxItems.ItemsSource = null;
            listBoxItems.ItemsSource = students;
        }

        private void listBoxItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Student selectedStudent = listBoxItems.SelectedItem as Student;
            if (selectedStudent != null)
            {
                // MessageBox.Show("Idul este: " + selectedStudent.Id);
                textboxFirstName.Text = selectedStudent.FirstName;
                textboxLastName.Text = selectedStudent.LastName;
                comboboxGender.SelectedItem = selectedStudent.Gender;
                datepickerDateOfBirth.SelectedDate = selectedStudent.DateOfBirth;
                btnUpdate.Content = "Update";
            }
            else
            {
                ResetStudent();
                btnUpdate.Content = "Save";
            }

        }

        private void ResetStudent()
        {
            textboxFirstName.Text = null;
            textboxLastName.Text = null;
            comboboxGender.SelectedItem = null;
            datepickerDateOfBirth.SelectedDate = null;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Student selectedStudent = listBoxItems.SelectedItem as Student;
                if (selectedStudent != null)
                {
                    if (university.DeleteStudentById(selectedStudent.Id))
                    {
                        MessageBox.Show("Studentul a fost sters!");
                        ResetStudent();
                        LoadStudents();
                    }
                    else
                    {
                        MessageBox.Show("Studentul nu exista!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecteaza un student!");
            }
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Student selectedStudent = listBoxItems.SelectedItem as Student;
                if (selectedStudent != null)
                {
                    if (string.IsNullOrEmpty(textboxFirstName.Text) || string.IsNullOrEmpty(textboxLastName.Text))
                    {
                        MessageBox.Show("Campuri lipsa!");
                    }
                    else
                    {
                        university.UpdateStudentById(selectedStudent.Id, textboxFirstName.Text, textboxLastName.Text);
                        LoadStudents();
                    }
                }
                else
                {

                    university.AddStudent(textboxFirstName.Text, textboxLastName.Text, datepickerDateOfBirth.SelectedDate.Value, (Gender)comboboxGender.SelectedItem);
                    LoadStudents();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecteaza un student!");
            }
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            listBoxItems.SelectedItem = null;
        }
    }
}