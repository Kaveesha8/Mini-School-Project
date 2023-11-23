using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;

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

        public Subject GetSubjectById(int subjectId)
        {
            return _context.Set<Subject>().FirstOrDefault(s=>s.Id==subjectId);
        }
        public IEnumerable<Subject> GetAllSubjects()
        {
            return _context.Set<Subject>().ToList();
        }
    }
}
