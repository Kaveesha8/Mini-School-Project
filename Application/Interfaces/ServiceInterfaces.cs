using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.Interfaces
{
    public interface IStudentService
    {
        void AddStudent(Student student);

        void DeleteStudent(Student student);

        void AssignSubject(Student student,Subject subject);

        ICollection<Student> GetStudents();
    }

    public interface ISubjectService
    {
        void AddSubject(Subject subject);
    }
}
