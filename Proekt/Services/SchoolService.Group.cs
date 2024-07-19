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
        private List<Group> groups = new List<Group>();
        public void AddGroup(string? name)
        {
            int id = groups.Count > 0 ? groups.Max(f => f.Id) + 1 : 1;
            groups.Add(new Group { Id = id, Name = name });
        }
        public void UpdateGroup(int id, string? name)
        {
            var group = groups.FirstOrDefault(f => f.Id == id);
            if (group != null)
            {
                group.Name = name;
            }
            else
            {
                Console.WriteLine("Group not Found!");
            }
        }
        public void DeleteGroup(int id)
        {
            var group = groups.FirstOrDefault(f => f.Id == id);
            if (group != null)
            {
                groups.Remove(group);
            }
            else
            {
                Console.WriteLine("Group Not Found!");
            }
        }
        public void ListGroup()
        {
            foreach (var group in groups)
            {
                Console.WriteLine($"GRoupId: {group.Id}, Name: {group.Name}");
            }
        }
    }
}
