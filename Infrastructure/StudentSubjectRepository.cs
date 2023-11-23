using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;

namespace Infrastructure
{
    public class StudentSubjectRepository : IStudentSubjectRepository
    {
        private readonly AppDbContext _context;
        public StudentSubjectRepository(AppDbContext context)
        {
            _context=context;
        }

        public void AssignStudentToSubject(StudentSubject studentSubject)
        {
            _context.Set<StudentSubject>().Add(studentSubject);
            _context.SaveChanges();
        }

        public IEnumerable<StudentSubject> GetAllStudentSubjects()
        {
            return _context.Set<StudentSubject>().ToList();
        }
    }
}
