using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using System.Data.Entity;


namespace Infrastructure
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _context;

        public SubjectRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddSubject(Subject subject)
        {
            _context.Set<Subject>().Add(subject);
            _context.SaveChanges();
        }
        public void DeleteSubject(Subject subject)
        {
            _context.Subjects.Remove(subject);
            _context.SaveChanges();
        }
        public void AssignStudent(Subject subject, Student student)
        {
            var s = _context.Subjects.First(s => s.Id == subject.Id);

            if (s.Students == null)
            {
                s.Students = new List<Student>();
            }

            s.Students.Add(student);

            _context.Subjects.Update(s);

            _context.SaveChanges();
        }
        public ICollection<Subject> GetSubjects()
        {
            return _context.Subjects.ToList();
        }

     
        public Subject GetSubjectById(int subjectId)
        {
            var subject= _context.Subjects.FirstOrDefault(s => s.Id == subjectId);
            return subject;
           
        }

        public List<Student> GetSubjectStudentsList(int subjectId)
        {
            var subject = _context.Subjects
            .Include(s => s.Students)
            .Where(s => s.Id == subjectId).SelectMany(s => s.Students).ToList();
            var studentList = subject;
            return studentList.ToList();

        }

    }
}
