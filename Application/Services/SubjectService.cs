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


    }
}
