using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Student>? Students { get; set; }

    }
}
