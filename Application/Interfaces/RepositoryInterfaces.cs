using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.Interfaces
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);

        void AssignSubject(Student student,Subject subject);
        Student GetStudentById(int studentId);
        IEnumerable<Student> GetAllStudents();
    }

    public interface ISubjectRepository
    {
        void AddSubject(Subject subject);
        Subject GetSubjectById(int subjectId);
        IEnumerable<Subject> GetAllSubjects();

    }
}
