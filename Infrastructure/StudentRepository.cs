using System;
using System.Collections.Generic;
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

        public Student GetStudentById(int studentId)
        {
            return _context.Set<Student>().FirstOrDefault(s=>s.Id==studentId);

        }

        public IEnumerable<Student> GetAllStudents() 
        {
            return _context.Set<Student>().ToList();
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
    }
}
