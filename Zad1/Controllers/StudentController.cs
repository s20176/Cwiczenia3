using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Zad1.Models;
using Zad1.Services;

namespace Zad1.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {

        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult getStudents()
        {
            try
            {
                var students = _studentService.getStudents();
                if (students.Count == 0)
                {
                    return NotFound();
                }
                return Ok(students);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("{indexNumber}")]
        public IActionResult getStudent(string indexNumber)
        {
            try
            {
                Student student = _studentService.getStudent(indexNumber);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult addStudent(Student student)
        {
            if (!validateStudent(student))
            {
                return BadRequest("Przekazano niepoprawne dane studenta");
            }
            try
            {
                bool result=_studentService.addStudent(student);
                if (result)
                {
                    return Ok(student);
                }
                return BadRequest("Istnieje student z podanym numerem indeksu");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{indexNumber}")]
        public IActionResult updateStudent(string indexNumber,Student student)
        {
            if (!validateStudent(student)||!student.IndexNumber.Equals(indexNumber))
            {
                return BadRequest("Przekazano niepoprawne dane studenta");
            }
            Student result=_studentService.updateStudent(indexNumber,student);
            if(result == null)
            {
                return NotFound("Nie istnieje student z podanym numerem indeksu");
            }
            return Ok(student);
        }

        [HttpDelete("{indexNumber}")]
        public IActionResult deleteStudent(string indexNumber)
        {
            try
            {
                bool result = _studentService.deleteStudent(indexNumber);
                if (result)
                {
                    return Ok(indexNumber);
                }
                return NotFound("Nie znaleziono studenta o podanym numerze indeksu");
            }
            catch
            {
                return BadRequest();
            }
        }

        private bool validateStudent(Student student)
        {
            if (student.FirstName == null || student.FirstName.Equals("")|| student.LastName == null || student.LastName.Equals("") ||
                student.BirthDate == null || student.BirthDate.Equals("") || student.StudiesName == null || student.StudiesName.Equals("") ||
                student.StudiesMode == null || student.StudiesMode.Equals("") || student.FathersName == null || student.FathersName.Equals("") ||
                student.MothersName == null || student.MothersName.Equals("")||student.IndexNumber==null)
            {
                return false;
            }
            var regex = new Regex(@"^[s][0-9]+$");
            var match=regex.Match(student.IndexNumber);
            if (!match.Success)
            {
                return false;
            }
            return true;
        }
    }
}
