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
        public void AddStudent(Student student)
        {
            _studentService.AddStudent(student);
        }

        [HttpDelete(Name ="DeleteStudent")]
        public void DeleteStudent(Student student)
        {
            _studentService.DeleteStudent(student);
        }

        [HttpPost( "AssignSubject")]
        public void AssignSubject(AssignRequestModel assignRequestModel)
        {
            Student student = new Student()
            {
                Id = assignRequestModel.Student.Id
            };

            Subject subject = new Subject() 
            {
                Id=assignRequestModel.Subject.Id
            };

            _studentService.AssignSubject( student,subject);
        }

        [HttpGet(Name = "GetStudents")]
        public ICollection<Student> GetStudents()
        {
            return _studentService.GetStudents();
        }
    }
}
