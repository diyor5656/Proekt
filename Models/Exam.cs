using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Exam
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public string Day1 { get; set; }
        public string TimeOn { get; set; }
        public string TimeOff { get; set; }
        public List<Exam> ExamList { get; set; } = new List<Exam>();
    }
}
