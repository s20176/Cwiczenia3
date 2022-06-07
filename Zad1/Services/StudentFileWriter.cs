using System.Collections.Generic;
using System.IO;

namespace Zad1.Services
{
    public class StudentFileWriter
    {
        public static string filePath = "students.txt";

        public void addStudentToFile(string line)
        {
            try
            {
                using (StreamWriter stream = new StreamWriter(filePath, true))
                {
                    stream.WriteLine(line);
                }
            }
            catch
            {

            }
        }
        public IEnumerable<string> getStudentsFromFile()
        {
            List<string> students = new List<string>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    students.Add(line);
                }
            }
            return students;
        }
    }
}
