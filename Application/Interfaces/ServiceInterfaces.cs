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
        Student GetStudentById(int id);

        ICollection<Subject> GetStudentSubjectsList(int id);
    }

    public interface ISubjectService
    {
        void AddSubject(Subject subject);

        void DeleteSubject(Subject subject);

        void AssignStudent(Subject subject, Student student);

        ICollection<Subject> GetSubjects();

        Subject GetSubjectById(int id);

        ICollection<Student> GetSubjectStudentsList(int id);
    }
}
