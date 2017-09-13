using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLibrary
{
    public enum Gender
    {
        F, M
    }
    public class Student
    {

        public string LastName;
        public string FirstName;
        //private int age;
        public Gender Gender { get; private set; }
        private List<double> Marks;
        public DateTime DateOfBirth { get; private set; }

        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;
                if (DateOfBirth > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }
        public int Id
        {
            get; private set;
        }
        public void AddMark(double mark)
        {
            Marks.Add(mark);
        }

        public Student(int id, String firstname, String lastname, DateTime dateofbirth, Gender gender)
        {
            this.Id = id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.DateOfBirth = dateofbirth;
            this.Gender = gender;
            this.Marks = new List<double>();
        }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        public double Average
        {
            get
            {

                if (Marks.Count != 0)
                {
                    double sum = 0;
                    foreach (double mark in Marks)
                    {
                        sum = sum + mark;
                    }
                    return sum / Marks.Count;
                }
                else
                    return 0;

            }
        }

        public override string ToString()
        {
            return string.Format("{4} - {0}({1} ani/{2}) - Media: {3}", FullName, Age, Gender, Average, Id);
        }
    }
}
