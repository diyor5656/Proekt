using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Proekt.Services
{
    public partial class SchoolService
    {
        public void AddRoom(string jsonPath)
        {
            List<Room> rooms = GetRooms(jsonPath);

            Console.Write("Enter Room Name: ");
            string roomName = Console.ReadLine();

            int newId = rooms.Count > 0 ? rooms.Max(r => r.Id) + 1 : 1;

            Room newRoom = new Room
            {
                Id = newId,
                Name = roomName
            };

            rooms.Add(newRoom);
            SaveRooms(jsonPath, rooms);

            Console.WriteLine("Room added successfully.");
        }

        public void UpdateRoom(string jsonPath)
        {
            List<Room> rooms = GetRooms(jsonPath);

            Console.Write("Enter Room Id for update : ");
            int roomId;
            while (!int.TryParse(Console.ReadLine(), out roomId))
            {
                Console.Write("Please enter a valid Id: ");
            }

            Room roomToUpdate = rooms.FirstOrDefault(r => r.Id == roomId);
            if (roomToUpdate == null)
            {
                Console.WriteLine("Room not found.");
                return;
            }

            Console.Write("Enter New Name (leave blank to keep current): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                roomToUpdate.Name = newName;
            }

            SaveRooms(jsonPath, rooms);
            Console.WriteLine("Room updated successfully.");
        }

        public void DeleteRoom(string jsonPath)
        {
            List<Room> rooms = GetRooms(jsonPath);

            Console.Write("Enter Room Id to Delete: ");
            int roomId;
            while (!int.TryParse(Console.ReadLine(), out roomId))
            {
                Console.Write("Please enter a valid Id: ");
            }

            Room roomToDelete = rooms.FirstOrDefault(r => r.Id == roomId);
            if (roomToDelete == null)
            {
                Console.WriteLine("Room not found.");
                return;
            }

            rooms.Remove(roomToDelete);
            SaveRooms(jsonPath, rooms);

            Console.WriteLine("Room deleted successfully.");
        }

        public List<Room> GetRooms(string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                return new List<Room>();
            }

            string jsonFromFile = File.ReadAllText(jsonPath);
            var rooms = string.IsNullOrEmpty(jsonFromFile) ? new List<Room>() : JsonSerializer.Deserialize<List<Room>>(jsonFromFile);

            Console.WriteLine("Rooms List:");
            foreach (var room in rooms)
            {
                Console.WriteLine($"Id: {room.Id}, Name: {room.Name}");
            }

            return rooms;
        }

        public void SaveRooms(string jsonPath, List<Room> rooms)
        {
            string serialized = JsonSerializer.Serialize(rooms);
            File.WriteAllText(jsonPath, serialized);
        }
    }
}
