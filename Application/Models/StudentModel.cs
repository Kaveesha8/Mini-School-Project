using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.Models
{
    public class StudentModel
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public DateTime Date { get; set; }
        public string? Address { get; set; }
        public ICollection<Subject>? Subjects { get; set; }
    }
}
