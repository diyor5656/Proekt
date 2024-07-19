using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int RoomID { get; set; }
        public Room Room { get; set; }
        public List<Booking> Grouplist { get; set; }
    }
}
