using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityLibrary;
//afisez meniu optiune nr
//alegeti optiune:
//1 adaugare
//2 afisare
//3 stergere
//0 exit
//student: id, string nume,string prenume, int varsta, gen enum(caracter)
namespace ConsoleApp1
{
    class Program
    {

        static University university=new University();
        static void AddMarkToStudent()
        {
            Console.Write("Introdu id-ul studentului: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Introdu nota: ");
            double mark = Convert.ToDouble(Console.ReadLine());
            List<Student> students = university.GetAllStudents();


            if (university.AddMarkToStudentById(id, mark))
            {
                Console.WriteLine("Nota a fost adaugata.");
            }
            else
            {
                Console.WriteLine("Studentul nu a fost gasit: ");
            }
        }

        static void ShowStudents()
        {
            List<Student> students = university.GetAllStudents();
            if (students.Count() != 0)
            {
                foreach (Student student in students)
                {
                    Console.WriteLine(student.ToString());
                }
            }
            else
            {
                Console.WriteLine("Nu exista studenti: ");
            }

        }
        static void ReadStudent()
        {
            string firstName;
            string lastName;
            Gender gen = Gender.M;


            Console.Write("Nume: ");
            lastName = Console.ReadLine();


            Console.Write("Prenume: ");
            firstName = Console.ReadLine();


            Console.Write("Ziua nasterii: ");
            int day = Convert.ToInt32(Console.ReadLine());


            Console.Write("Luna nasteri: ");
            int month = Convert.ToInt32(Console.ReadLine());


            Console.Write("Anul nasterii: ");
            int year = Convert.ToInt32(Console.ReadLine());

            DateTime dateOfBirth = new DateTime(year, month, day);


            bool isInputCorect = false;
            do
            {
                Console.Write("Sex: ");
                string gender = Console.ReadLine().Trim().ToUpper();
                if (gender == "M")
                {
                    gen = Gender.M;
                    isInputCorect = true;
                }
                else if (gender == "F")
                {
                    gen = Gender.F;
                    isInputCorect = true;
                }
                else Console.WriteLine("Format incorect.");
            } while (isInputCorect == false);

            university.AddStudent(firstName, lastName, dateOfBirth, gen);
        }

        static void UpdateStudentById()
        {
                    

            Console.Write("Introdu Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Introdu numele: ");
            string firstName =Console.ReadLine();

            Console.Write("Introdu prenumele: ");
            string lastName =Console.ReadLine();

            university.UpdateStudentById(id, firstName, lastName);

        }

        static void DeleteStudent()
        {
            List<Student> students = university.GetAllStudents();
            Console.Write("Introduceti Id student:");
            int id = Convert.ToInt32(Console.ReadLine());


            if (university.DeleteStudentById(id))
            {
                Console.WriteLine("Studentul a fost sters.");

            }
            else
            {
                Console.WriteLine("Studentul nu a fost gasit");
            }
        }
        static void Main(string[] args)
        {
            int option;

            // Student s = new Student(1, "a", "b", 2, Gender.Male);
            // Console.WriteLine(s.ToString());
            /* Console.WriteLine("1 - Adaugare student");
             Console.WriteLine("2 - Afisare toti studentii");
             Console.WriteLine("3 - Stergere student dupa Id");
             Console.WriteLine("4 - Adaugare nota pentru student");
             Console.WriteLine("0 - Exit");*/

            /* students.Add(new Student(id++, "abc", "def", 4, Gender.M));
             students.Add(new Student(id++, "sss", "www", 5, Gender.F));
             students.Add(new Student(id++, "ddd", "eee", 6, Gender.M));
             students.Add(new Student(id++, "fff", "rrr", 7, Gender.F));
             students.Add(new Student(id++, "ggg", "ttt", 8, Gender.M));
             students.Add(new Student(id++, "hhh", "yyy", 9, Gender.F));
             */
            do
            {
                Console.WriteLine();
                Console.WriteLine("1 - Adaugare student");
                Console.WriteLine("2 - Afisare toti studentii");
                Console.WriteLine("3 - Stergere student dupa Id");
                Console.WriteLine("4 - Adaugare nota pentru student");
                Console.WriteLine("5 - Modifica nume pentru student");
                Console.WriteLine("0 - Exit");

                Console.Write("Optiunea dvs. este: ");


                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        ReadStudent();
                        break;
                    case 2:
                        ShowStudents();
                        break;
                    case 3:
                        ShowStudents();
                        DeleteStudent();
                        break;
                    case 4:
                        ShowStudents();
                        AddMarkToStudent();
                        break;
                    case 5:
                        ShowStudents();
                        UpdateStudentById();
                        break;
                }

            } while (option != 0);
        }
    }
}