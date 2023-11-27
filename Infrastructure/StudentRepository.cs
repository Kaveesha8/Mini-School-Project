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
        
        public async void AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync(); 
        }

        public Student GetStudentById(int studentId)
        {
            return _context.Set<Student>().FirstOrDefault(s=>s.Id==studentId);

        }

        public IEnumerable<Student> GetAllStudents() 
        {
            return _context.Set<Student>().ToList();
        }
    }
}
