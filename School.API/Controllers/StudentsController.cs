using Application.Interfaces;
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

        [HttpGet(Name = "GetStudents")]
        public ICollection<Student> GetStudents()
        {
            return _studentService.GetStudents();
        }
    }
}
