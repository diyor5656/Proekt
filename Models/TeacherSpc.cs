using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TeacherSpc
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int SpecialistId { get; set; }
        public Specialist Specialist { get; set; }
    }
}
