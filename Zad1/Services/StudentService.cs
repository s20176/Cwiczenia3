using System.Collections.Generic;
using Zad1.Models;

namespace Zad1.Services
{
    public class StudentService
    {

        private StudentFileWriter _writer;

        public StudentService()
        {
            _writer = new StudentFileWriter();
        }

        public IEnumerable<Student> getStudents()
        {
            List<string> lines = (List<string>)_writer.getStudentsFromFile();
            List<Student> students = new List<Student>();
            foreach (string line in lines)
            {
                string[] parts = line.Split(",");
                //Student student = new Student(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[7], parts[8]);
                //students.Add(student);
            }
            return students;
        }

        public string addStudent(Student student)
        {
            //string line = student.getFirstName() + "," + student.getLastName() + "," + student.getIndex() + "," + student.getBirthdate() + "," +
            //    student.getStudiesName() + "," + student.getStudiesMode() + "," + student.getEmail() + "," + student.getFathersName() + "," + student.getMothersName();
           // _writer.addStudentToFile(line);
            return "lalala";
        }
    }
}
