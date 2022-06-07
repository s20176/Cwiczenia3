using System.Collections.Generic;
using Zad1.Models;

namespace Zad1.Services
{
    public interface IStudentService
    {
        public HashSet<Student> getStudents();
        public bool addStudent(Student student);

        public Student getStudent(string indexNumber);

        public Student updateStudent(string indexNumber,Student student);

        public bool deleteStudent(string indexNumber);
    }
}
