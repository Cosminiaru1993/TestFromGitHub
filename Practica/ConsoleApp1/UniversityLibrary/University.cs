using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLibrary
{
    public class University
    {
        private int id = 0;
        private int option;

        private List<Student> students = new List<Student>();

        public void AddStudent(string firstName, string lastName, DateTime dateOfBirth, Gender gen)
        {
            students.Add(new Student(id++, firstName, lastName, dateOfBirth, gen));
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public bool AddMarkToStudentById(int id, double mark)
        {
            foreach (Student student in students)
            {
                if (id == student.Id)
                {
                    student.AddMark(mark);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteStudentById(int id)
        {
            foreach (Student student in students)
            {
                if (id == student.Id)
                {
                    students.Remove(student);
                    return true;
                }
            }
            return false;

        }

        public void UpdateStudentById(int id, string firstname, string lastname)
        {
            foreach (Student student in students)
            {
                if (id == student.Id)
                {
                    student.FirstName = firstname;
                    student.LastName = lastname;
                }
            }
        }
    }
}