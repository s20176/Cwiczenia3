using System.Collections.Generic;
using System.IO;
using Zad1.Models;

namespace Zad1.Services
{
    public class FileStudentService : IStudentService
    {
        public string filePath = "students.csv";

        public bool addStudent(Student student)
        {
            bool indexExists=indexNumberExists(student.IndexNumber);
            if (indexExists)
            {
                return false;
            }
            string line = parseStudent(student);
            using (StreamWriter stream = new StreamWriter(filePath, true))
            {
                stream.WriteLine(line);
            }
            return true;
        }

        public HashSet<Student> getStudents()
        {
            HashSet<Student> students = readStudentsFromFile();
            return students;
        }

        public Student getStudent(string indexNumber)
        {
            HashSet<Student> students = readStudentsFromFile();
            Student result = null;
            foreach(Student student in students)
            {
                if(student.IndexNumber.Equals(indexNumber))
                {
                    result = student;
                }
            }
            return result;
        }

        public Student updateStudent(string indexNumber,Student student)
        {
            HashSet<Student> students = readStudentsFromFile();
            Student result = null;
            foreach (Student s in students)
            {
                if (s.IndexNumber.Equals(indexNumber))
                {
                    s.FirstName = student.FirstName;
                    s.LastName = student.LastName;
                    s.BirthDate = student.BirthDate;
                    s.StudiesName = student.StudiesName;
                    s.StudiesMode = student.StudiesMode;
                    s.Email = student.Email;
                    s.FathersName = student.FathersName;
                    s.MothersName = student.MothersName;
                    result = s;

                }
            }
            if (result != null)
            {
                writeStudentsToFile(students);
            }
            return result;
        }

        public bool deleteStudent(string indexNumber)
        {
            bool result = false;
            HashSet<Student> students = readStudentsFromFile();
            foreach (Student student in students)
            {
                if (student.IndexNumber.Equals(indexNumber))
                {
                    students.Remove(student);
                    result = true;
                }
            }
            if (result)
            {
                writeStudentsToFile(students);
            }
            return result;
        }

        private HashSet<Student> readStudentsFromFile()
        {
            HashSet<Student> students = new HashSet<Student>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] arr = line.Split(",");
                    Student student = new Student();
                    student.FirstName = arr[0];
                    student.LastName = arr[1];
                    student.IndexNumber = arr[2];
                    student.BirthDate = arr[3];
                    student.StudiesName = arr[4];
                    student.StudiesMode = arr[5];
                    student.Email = arr[6];
                    student.FathersName = arr[7];
                    student.MothersName = arr[8];
                    students.Add(student);
                }
            }
            return students;
        }

        private void writeStudentsToFile(HashSet<Student> students)
        {

            using (StreamWriter stream = new StreamWriter(filePath))
            {
                foreach (Student student in students)
                {
                    stream.WriteLine(parseStudent(student));
                }
            }
        }

        private string parseStudent(Student student)
        {
            string line = student.FirstName + "," + student.LastName + "," + student.IndexNumber + "," + student.BirthDate + "," + student.StudiesName + "," + student.StudiesMode +
                "," + student.Email + "," + student.FathersName + "," + student.MothersName;
            return line;
        }

        private bool indexNumberExists(string indexNumber)
        {
            HashSet<Student> students = readStudentsFromFile();
            foreach (Student student in students)
            {
                if (student.IndexNumber.Equals(indexNumber))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
