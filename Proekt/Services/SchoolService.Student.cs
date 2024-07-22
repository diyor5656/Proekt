using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Models;

namespace Proekt.Services
{
    public partial class SchoolService
    {
        public void AddStudent(string jsonPath)
        {
            List<Puple> students = GetStudents(jsonPath);

            Console.Write("Enter Student Name: ");
            string studentName = Console.ReadLine();

            int newId = students.Count > 0 ? students.Max(s => s.Id) + 1 : 1;

            Puple newStudent = new Puple
            {
                Id = newId,
                Name = studentName
            };

            students.Add(newStudent);
            SaveStudents(jsonPath, students);

            Console.WriteLine("Student added successfully.");
        }

        public void UpdateStudent(string jsonPath)
        {
            List<Puple> students = GetStudents(jsonPath);

            Console.Write("Enter Student Id for update: ");
            int studentId;
            while (!int.TryParse(Console.ReadLine(), out studentId))
            {
                Console.Write("Please enter a valid Id: ");
            }

            Puple studentToUpdate = students.FirstOrDefault(s => s.Id == studentId);
            if (studentToUpdate == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write("Enter New Name (leave blank to keep current): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                studentToUpdate.Name = newName;
            }

            SaveStudents(jsonPath, students);
            Console.WriteLine("Student updated successfully.");
        }

        public void DeleteStudent(string jsonPath)
        {
            List<Puple> students = GetStudents(jsonPath);

            Console.Write("Enter Student Id to Delete: ");
            int studentId;
            while (!int.TryParse(Console.ReadLine(), out studentId))
            {
                Console.Write("Please enter a valid Id: ");
            }

            Puple studentToDelete = students.FirstOrDefault(s => s.Id == studentId);
            if (studentToDelete == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            students.Remove(studentToDelete);
            SaveStudents(jsonPath, students);

            Console.WriteLine("Student deleted successfully.");
        }

        public List<Puple> GetStudents(string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                return new List<Puple>();
            }

            string jsonFromFile = File.ReadAllText(jsonPath);
            var students = string.IsNullOrEmpty(jsonFromFile) ? new List<Puple>() : JsonSerializer.Deserialize<List<Puple>>(jsonFromFile);

            Console.WriteLine("Students List:");
            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}");
            }

            return students;
        }

        public void SaveStudents(string jsonPath, List<Puple> students)
        {
            string serialized = JsonSerializer.Serialize(students);
            File.WriteAllText(jsonPath, serialized);
        }
    }
}

