﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void AddStudent(Student student)
        {
            _studentRepository.AddStudent(student);
        }
        public void DeleteStudent(Student student)
        {
            _studentRepository.DeleteStudent(student);
        }
        public void AssignSubject(Student student, Subject subject)
        {
            _studentRepository.AssignSubject(student,subject);
        }

        public ICollection<Student> GetStudents()
        {
            return _studentRepository.GetStudents();
        }

        public Student GetStudentById(int studentId)
        {
            return _studentRepository.GetStudentById(studentId);
        }
        public ICollection<Subject> GetStudentSubjectsList(int studentId)
        {
            return _studentRepository.GetStudentSubjectsList(studentId);
        }

     
    }
}
