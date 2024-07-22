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
        public void AddGroup(string jsonPath)
        {
            List<Group> groups = GetGroups(jsonPath);

            Console.Write("Enter Group Name: ");
            string groupName = Console.ReadLine();

            int newId = groups.Count > 0 ? groups.Max(g => g.Id) + 1 : 1;

            Group newGroup = new Group
            {
                Id = newId,
                Name = groupName
            };

            groups.Add(newGroup);
            SaveGroups(jsonPath, groups);

            Console.WriteLine("Group added successfully.");
        }

        public void UpdateGroup(string jsonPath)
        {
            List<Group> groups = GetGroups(jsonPath);

            Console.Write("Enter Group Id for update : ");
            int groupId;
            while (!int.TryParse(Console.ReadLine(), out groupId))
            {
                Console.Write("Please enter a valid Id: ");
            }

            Group groupToUpdate = groups.FirstOrDefault(g => g.Id == groupId);
            if (groupToUpdate == null)
            {
                Console.WriteLine("Group not found.");
                return;
            }

            Console.Write("Enter New Name (leave blank to keep current): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                groupToUpdate.Name = newName;
            }

            SaveGroups(jsonPath, groups);
            Console.WriteLine("Group updated successfully.");
        }

        public void DeleteGroup(string jsonPath)
        {
            List<Group> groups = GetGroups(jsonPath);

            Console.Write("Enter Group Id to Delete: ");
            int groupId;
            while (!int.TryParse(Console.ReadLine(), out groupId))
            {
                Console.Write("Please enter a valid Id: ");
            }

            Group groupToDelete = groups.FirstOrDefault(g => g.Id == groupId);
            if (groupToDelete == null)
            {
                Console.WriteLine("Group not found.");
                return;
            }

            groups.Remove(groupToDelete);
            SaveGroups(jsonPath, groups);

            Console.WriteLine("Group deleted successfully.");
        }

        public List<Group> GetGroups(string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                return new List<Group>();
            }

            string jsonFromFile = File.ReadAllText(jsonPath);
            var groups = string.IsNullOrEmpty(jsonFromFile) ? new List<Group>() : JsonSerializer.Deserialize<List<Group>>(jsonFromFile);

            Console.WriteLine("Groups List:");
            foreach (var group in groups)
            {
                Console.WriteLine($"Id: {group.Id}, Name: {group.Name}");
            }

            return groups;
        }

        public void SaveGroups(string jsonPath, List<Group> groups)
        {
            string serialized = JsonSerializer.Serialize(groups);
            File.WriteAllText(jsonPath, serialized);
        }
    }
}
