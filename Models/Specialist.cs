using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Specialist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Stack { get; set; }
        public List<TeacherSpc> TeacherSpc { get; set; } = new List<TeacherSpc>();

    }
}
