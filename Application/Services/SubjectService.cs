using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;

namespace Application.Services
{
    public class SubjectService : ISubjectService
    {
        private ISubjectRepository _subjectRepository;
        
        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public void AddSubject(Subject subject)
        {
            _subjectRepository.AddSubject(subject);

        }

        public void DeleteSubject(Subject subject)
        {
            _subjectRepository.DeleteSubject(subject);
        }
        public void AssignStudent(Subject subject,Student student)
        {
            _subjectRepository.AssignStudent(subject, student);
        }
        public ICollection<Subject> GetSubjects()
        {
            return _subjectRepository.GetSubjects();
        }

        public Subject GetSubjectById(int subjectId)
        {
            return _subjectRepository.GetSubjectById(subjectId);
        }
        public ICollection<Student> GetSubjectStudentsList(int subjectId)
        {
            return _subjectRepository.GetSubjectStudentsList(subjectId);
        }
    }


    
}
