using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.Models
{
    public class AssignRequestModel
    {
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }


}
