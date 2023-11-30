using Application.Interfaces;
using Application.Models;
using Application.Services;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        
        }

        [HttpPost(Name = "AddStudent")]
        public IActionResult AddStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Invalid student data");
            }
            _studentService.AddStudent(student);

            return Ok("Student Added Successfully");
        }

        [HttpDelete(Name = "DeleteStudent")]
        public IActionResult DeleteStudent([FromBody] Student student)
        {
            if(student == null)
            {
                return BadRequest("Invalid student data");
            }
            _studentService.DeleteStudent(student);

            return Ok("Student deleted successfully");
        }

        [HttpPost("AssignSubject")]
        public IActionResult AssignSubject([FromBody] AssignRequestModel assignRequestModelStudent)
        {
            if (assignRequestModelStudent == null)
            {
                return BadRequest("Invalid request data");
            }
            Student student = new Student()
            {
                Id = assignRequestModelStudent.Student.Id
            };

            Subject subject = new Subject() 
            {
                Id=assignRequestModelStudent.Subject.Id
            };

            _studentService.AssignSubject( student,subject);

            return Ok("Subject assigned successfully");
        }

        [HttpGet(Name = "GetStudents")]
        public ICollection<Student> GetStudents()
        {
            return _studentService.GetStudents();
        }

       
    }
  
}
