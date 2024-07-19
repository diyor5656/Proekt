using Models;

namespace Proekt.Services
{
    public partial class SchoolService
    {
        private List<Teacher> teachers = new List<Teacher>();
        private List<Specialist> specialists = new List<Specialist>();
        private List<Teacher> Teachers = new List<Teacher>();
        private List<Room> rooms = new List<Room>();
           
        public void AttachSpecialistToTeacher(int teacherId, int specialistId)
        {
            var teacher = teachers.FirstOrDefault(t => t.Id == teacherId);
            var specialist = specialists.FirstOrDefault(s => s.Id == specialistId);

            if (teacher == null || specialist == null)
            {
                Console.WriteLine("Invalid teacher or Specialist ID.");
                return;
            }

            var teacherSpecialist = new TeacherSpc
            {
                TeacherId = teacherId,
                Teacher = teacher,
                SpecialistId = specialistId,
                Specialist = specialist
            };

            teacher.TeacherSpc.Add(teacherSpecialist);
            specialist.TeacherSpc.Add(teacherSpecialist);
        }
        public void Booking(int teacherId, int roomId, int groupId)
        {
            var teacher = teachers.FirstOrDefault(t => t.Id == teacherId);
            var room = rooms.FirstOrDefault(r =>r.Id == roomId);
            var group = groups.FirstOrDefault(s => s.Id == groupId);
            if (teacher == null || group == null || room == null)
            {
                Console.WriteLine("Invalid teacher or room or group ID.");
                return;
            }
            var newgroup = new Booking
            {
                TeacherId = teacherId,
                Teacher = teacher,
                RoomId = roomId,
                Room = room,
                GroupId = groupId,
                Group = group,

            };

            group.Grouplist.Add(newgroup);
            room.Grouplist.Add(newgroup);
            teacher.Grouplist.Add(newgroup);
        }
        public void Exam(int teacherId, int roomId, int groupId,string SatrtOn,string EndOn,string day)
        {
            var teacher = teachers.FirstOrDefault(t => t.Id == teacherId);
            var room = rooms.FirstOrDefault(r => r.Id == roomId);
            var group = groups.FirstOrDefault(s => s.Id == groupId);
            if (teacher == null || group == null || room == null)
            {
                Console.WriteLine("Invalid teacher or group or room ID.");
                return;
            }
            var newgroup = new Booking
            {
                TeacherId = teacherId,
                Teacher = teacher,
                RoomId = roomId,
                Room = room,
                GroupId = groupId,
                Group = group,

            };

            group.Grouplist.Add(newgroup);
            room.Grouplist.Add(newgroup);
            teacher.Grouplist.Add(newgroup);
        }

    
        public void GetList()
        {
            if (teachers.Count > 0)
                foreach (var teacher in teachers)
                {
                    Console.WriteLine($"Teacher: {teacher.Name}");
                    foreach (var ts in teacher.TeacherSpc)
                    {
                        Console.WriteLine($"  Specialist: {ts.Specialist.Name}, Stack: {ts.Specialist.Stack}");
                    }
                }
            else
                Console.WriteLine("Teacher lis is empty.");
        }
        public void GetBigList()
        {
            if (teachers.Count > 0 && rooms.Count>0 && groups.Count>0)
                foreach (var teacher in teachers)
                {
                    Console.WriteLine($"Teacher: {teacher.Name}");
                    foreach (var ts in teacher.Grouplist)
                    {
                        Console.WriteLine($"  Room: {ts.Room.Name}, Group: {ts.Group.Name}");
                    }
                }
            else
                Console.WriteLine("Error!!!!");
        }
       
     
    }
}


