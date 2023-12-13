using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;

namespace Infrastructure
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context=context;
        }
        
        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges(); 
        }

        public void DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
        public void AssignSubject(Student student, Subject subject)
        {
            var s = _context.Students.First(s => s.Id == student.Id);

            if(s.Subjects == null)
            {
                s.Subjects = new List<Subject>();
            }

            s.Subjects.Add(subject);

            _context.Students.Update(s);

            _context.SaveChanges();
        }

        public ICollection<Student> GetStudents()
        {
            return _context.Students.Include(s => s.Subjects).ToList();
        }

        public Student GetStudentById(int studentId)
        {
            var student =  _context.Students.FirstOrDefault(s => s.Id == studentId);
            return student;
        }

        public List<Subject> GetStudentSubjectsList(int studentId)
        {
            var student = _context.Students
            .Include(s => s.Subjects)
            .Where(s => s.Id == studentId).SelectMany(s => s.Subjects).ToList();
            var subjectList = student;
            return subjectList.ToList();

        }

    }
}
