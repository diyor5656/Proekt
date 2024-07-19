using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int StudentsId { get; set; }
        public Puple Student { get; set; }
        public List<Group> Grouplist { get; set; }
    }
}
