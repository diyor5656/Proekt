using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int Number { get; set; }
        public List<Booking> Grouplist { get; set; } = new List<Booking>();
        public List<Exam> ExamList { get; set; } = new List<Exam>();

    }
}
