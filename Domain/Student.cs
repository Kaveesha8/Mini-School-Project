﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age {  get; set; }
        public DateTime Date { get; set; }
        public string? Address { get; set; }
        public ICollection<Subject>? Subjects { get; set; }

    }
}
