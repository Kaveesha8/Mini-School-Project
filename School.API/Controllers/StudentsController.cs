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
        private readonly ISubjectService _subjectService;

        public StudentsController(IStudentService studentService,ISubjectService subjectService)
        {
            _studentService = studentService;
            _subjectService = subjectService;
        
        }

        [HttpPost("AddStudent")]
        public IActionResult AddStudent(Student student)
        {
            if (student == null)
            {
                return BadRequest("Invalid student data");
            }
            _studentService.AddStudent(student);

            return Ok(new { message = "Student Added Successfully" });
        }

        [HttpDelete("DeleteStudent/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid student ID");
            }

            // Retrieve the student based on the ID
            Student studentToDelete = _studentService.GetStudentById(id);

            if (studentToDelete == null)
            {
                return NotFound("Student not found");
            }

            // Perform the deletion
            _studentService.DeleteStudent(studentToDelete);

            return Ok(new { message = "Student Deleted Successfully" });
        }


        [HttpPost("AssignSubject")]
        public IActionResult AssignSubject(AssignRequestModel assignRequestModel)
        {
            int studentId = assignRequestModel.StudentId;
            int subjectId = assignRequestModel.SubjectId;

            if (studentId <= 0 || subjectId <= 0)
            {
                return BadRequest("Invalid request data");
            }

            // Retrieve student and subject based on the IDs (you might want to add error handling here)
            Student student = _studentService.GetStudentById(studentId);
            Subject subject = _subjectService.GetSubjectById(subjectId);

            // Perform the logic to assign the subject to the student
            _studentService.AssignSubject(student, subject);

            return Ok(new { message = "Subject assigned successfully" });
        }

        [HttpGet("GetStudents")]
        public ICollection<Student> GetStudents()
        {
            var students = _studentService.GetStudents();
            return students;
        }


        [HttpGet("GetStudentSubjectsList/{studentId}")]
        public ActionResult<List<Subject>> SubjectList(int studentId)
        {
            ICollection<Subject> subjectList = _studentService.GetStudentSubjectsList(studentId);
            return Ok(subjectList);
        }

 
    }
  
}
