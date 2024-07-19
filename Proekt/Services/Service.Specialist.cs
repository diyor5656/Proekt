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
        public void AddSpecialist(string name, string stack)
        {
            int id = specialists.Count > 0 ? specialists.Max(a => a.Id) + 1 : 1;
            var spec = new Specialist { Id = id, Name = name, Stack = stack };
            specialists.Add(spec);
        }
        public void UpdateSpecialist(int id, string name, string stack)
        {
            var specialist = specialists.FirstOrDefault(a => a.Id == id);
            if (specialist != null)
            {
                specialist.Name = name;
                specialist.Stack = stack;
            }
            else
            {
                Console.WriteLine("Specialist Not Found!");
            }
        }
        public void DeleteSpecialist(int id)
        {
            var specialist = specialists.FirstOrDefault(a => a.Id == id);
            if (specialist != null)
            {
                specialists.Remove(specialist);
            }
            else
            {
                Console.WriteLine("Specialist Not Found!");
            }
        }
        public void ListSpecialists()
        {
            foreach (var specialist in specialists)
            {
                Console.WriteLine($"Specialist: {specialist.Id}, Name: {specialist.Name}, Stack: {specialist.Stack}");
            }
        }

    }
}
