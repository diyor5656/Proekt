using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proekt.Services
{
    public partial class SchoolService
    {
        
        public void AddRoom(string? name)
        {
            int id = rooms.Count > 0 ? rooms.Max(f => f.Id) + 1 : 1;
            rooms.Add(new Room { Id = id, Name = name });
        }
        public void UpdateRoom(int id, string? name)
        {
            var room = rooms.FirstOrDefault(f => f.Id == id);
            if (room != null)
            {
                room.Name = name;
            }
            else
            {
                Console.WriteLine("Room not Found!");
            }
        }
        public void DeleteRoom(int id)
        {
            var room = rooms.FirstOrDefault(f => f.Id == id);
            if (room != null)
            {
                rooms.Remove(room);
            }
            else
            {
                Console.WriteLine("Room Not Found!");
            }
        }
        public void ListRoom()
        {
            foreach (var room in rooms)
            {
                Console.WriteLine($"RoomId: {room.Id}, Name: {room.Name}");
            }
        }
    }
}
