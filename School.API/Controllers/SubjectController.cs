using Application.Interfaces;
using Application.Models;
using Application.Services;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectsController(ISubjectService subjectService)
        {

            _subjectService = subjectService;
        }

        [HttpPost(Name = "AddSubjects")]
        public IActionResult AddSubject([FromBody] Subject subject)
        {
            {
                if (subject == null)
                {
                    return BadRequest("Invalid Subject data");
                }
                _subjectService.AddSubject(subject);

                return Ok("Subject Added Successfully");
            }

        }

        [HttpDelete(Name = "DeleteSubject")]
        public IActionResult DeleteStudent([FromBody] Subject subject)
        {
            if (subject == null)
            {
                return BadRequest("Invalid student data");
            }
            _subjectService.DeleteSubject(subject);

            return Ok("Subject deleted successfully");
        }
        [HttpPost("AssignStudent")]
        public IActionResult AssignStudent([FromBody] AssignRequestModel AssignRequestModelSubject)
        {
            if (AssignRequestModelSubject == null)
            {
                return BadRequest("Invalid request data");
            }
            Subject subject = new Subject()
            {
                Id = AssignRequestModelSubject.Student.Id
            };

            Student student = new Student()
            {
                Id = AssignRequestModelSubject.Student.Id
            };

            _subjectService.AssignStudent(subject,student);

            return Ok("Subject assigned successfully");
        }

        [HttpGet(Name = "GetSubjects")]
        public ICollection<Subject> GetSubjects()
        {
            return _subjectService.GetSubjects();
        }

    }
}
