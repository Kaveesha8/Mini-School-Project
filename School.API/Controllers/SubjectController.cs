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

        [HttpPost( "AddSubject")]
        public IActionResult AddSubject( Subject subject)
        {
            {
                if (subject == null)
                {
                    return BadRequest("Invalid Subject data");
                }
                _subjectService.AddSubject(subject);

                return Ok(new { message = "Subject Added Successfully" });


            }

        }

        [HttpDelete("DeleteSubject/{id}")]
        public IActionResult DeleteSubject(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid subject ID");
            }

            // Retrieve the subject based on the ID
            Subject subjectToDelete = _subjectService.GetSubjectById(id);

            if (subjectToDelete == null)
            {
                return NotFound("Subject not found");
            }

            // Perform the deletion
            _subjectService.DeleteSubject(subjectToDelete);

            return Ok(new { message = "Subject Deleted Successfully" });
        }

      /*  [HttpPost("AssignStudent")]*/
       /* public IActionResult AssignStudent([FromBody] AssignRequestModel AssignRequestModelSubject)
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

            return Ok(new { message = "Subject assigned successfully" });

       
        }*/

        [HttpGet( "GetSubjects")]
        public ICollection<Subject> GetSubjects()
        {
            return _subjectService.GetSubjects();
        }

    }
}
