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
        public void AddSpecialist(string jsonPath)
        {
            List<Specialist> specialists = GetSpecialists(jsonPath);

            Console.Write("Enter Specialist Name: ");
            string specialistName = Console.ReadLine();
            Console.Write("Enter Specialist Stack: ");
            string specialistStack = Console.ReadLine();

            int newId = specialists.Count > 0 ? specialists.Max(s => s.Id) + 1 : 1;

            Specialist newSpecialist = new Specialist
            {
                Id = newId,
                Name = specialistName,
                Stack = specialistStack
            };

            specialists.Add(newSpecialist);
            SaveSpecialists(jsonPath, specialists);

            Console.WriteLine("Specialist added successfully.");
        }

        public void UpdateSpecialist(string jsonPath)
        {
            List<Specialist> specialists = GetSpecialists(jsonPath);

            Console.Write("Enter Specialist Id for update : ");
            int specialistId;
            while (!int.TryParse(Console.ReadLine(), out specialistId))
            {
                Console.Write("Please enter a valid Id: ");
            }

            Specialist specialistToUpdate = specialists.FirstOrDefault(s => s.Id == specialistId);
            if (specialistToUpdate == null)
            {
                Console.WriteLine("Specialist not found.");
                return;
            }

            Console.Write("Enter New Name (leave blank to keep current): ");
            string newName = Console.ReadLine();
            Console.Write("Enter New Stack (leave blank to keep current): ");
            string newStack = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                specialistToUpdate.Name = newName;
            }
            if (!string.IsNullOrWhiteSpace(newStack))
            {
                specialistToUpdate.Stack = newStack;
            }

            SaveSpecialists(jsonPath, specialists);
            Console.WriteLine("Specialist updated successfully.");
        }

        public void DeleteSpecialist(string jsonPath)
        {
            List<Specialist> specialists = GetSpecialists(jsonPath);

            Console.Write("Enter Specialist Id to Delete: ");
            int specialistId;
            while (!int.TryParse(Console.ReadLine(), out specialistId))
            {
                Console.Write("Please enter a valid Id: ");
            }

            Specialist specialistToDelete = specialists.FirstOrDefault(s => s.Id == specialistId);
            if (specialistToDelete == null)
            {
                Console.WriteLine("Specialist not found.");
                return;
            }

            specialists.Remove(specialistToDelete);
            SaveSpecialists(jsonPath, specialists);

            Console.WriteLine("Specialist deleted successfully.");
        }

        public List<Specialist> GetSpecialists(string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                return new List<Specialist>();
            }

            string jsonFromFile = File.ReadAllText(jsonPath);
            var specialists = string.IsNullOrEmpty(jsonFromFile) ? new List<Specialist>() : JsonSerializer.Deserialize<List<Specialist>>(jsonFromFile);

            Console.WriteLine("Specialists List:");
            foreach (var specialist in specialists)
            {
                Console.WriteLine($"Id: {specialist.Id}, Name: {specialist.Name}, Stack: {specialist.Stack}");
            }

            return specialists;
        }

        public void SaveSpecialists(string jsonPath, List<Specialist> specialists)
        {
            string serialized = JsonSerializer.Serialize(specialists);
           
            if (!File.Exists(jsonPath))
            {
                File.WriteAllText(jsonPath, serialized);
            }
            
        }

    }
}
