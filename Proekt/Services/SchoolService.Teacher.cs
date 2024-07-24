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
        public static string GetTeacherPAth()
        {
            string currentPath = Directory.GetCurrentDirectory();
            currentPath += @"\teachers.json";
            return currentPath;
        }
        public void AddTeacher()
        {
            
            List<Teacher> teachers = GetTeachers();

            Console.Write("Enter Teacher Name: ");
            string teacherName = Console.ReadLine();

            int newId = teachers.Count > 0 ? teachers.Max(t => t.Id) + 1 : 1;

            Teacher newTeacher = new Teacher
            {
                Id = newId,
                Name = teacherName
            };

            teachers.Add(newTeacher);
            SaveTeachers( teachers);

            Console.WriteLine("Teacher added successfully.");
        }

        public void UpdateTeacher()
        {
            List<Teacher> teachers = GetTeachers();

            Console.Write("Enter Teacher Id for update : ");
            int teacherId;
            while (!int.TryParse(Console.ReadLine(), out teacherId))
            {
                Console.Write("Please enter a valid Id: ");
            }

            Teacher teacherToUpdate = teachers.FirstOrDefault(t => t.Id == teacherId);
            if (teacherToUpdate == null)
            {
                Console.WriteLine("Teacher not found.");
                return;
            }

            Console.Write("Enter New Name (leave blank to keep current): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                teacherToUpdate.Name = newName;
            }

            SaveTeachers( teachers);
            Console.WriteLine("Teacher updated successfully.");
        }

        public void DeleteTeacher()
        {
            List<Teacher> teachers = GetTeachers();

            Console.Write("Enter Teacher Id to Delete: ");
            int teacherId;
            while (!int.TryParse(Console.ReadLine(), out teacherId))
            {
                Console.Write("Please enter a valid Id: ");
            }

            Teacher teacherToDelete = teachers.FirstOrDefault(t => t.Id == teacherId);
            if (teacherToDelete == null)
            {
                Console.WriteLine("Teacher not found.");
                return;
            }

            teachers.Remove(teacherToDelete);
            SaveTeachers( teachers);

            Console.WriteLine("Teacher deleted successfully.");
        }

        public List<Teacher> GetTeachers()
        {
            if (!File.Exists(GetTeacherPAth()))
            {
                return new List<Teacher>();
            }

            string jsonFromFile = File.ReadAllText(GetTeacherPAth());
            var teachers = string.IsNullOrEmpty(jsonFromFile) ? new List<Teacher>() : JsonSerializer.Deserialize<List<Teacher>>(jsonFromFile);

            Console.WriteLine("Teachers List:");
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"Id: {teacher.Id}, Name: {teacher.Name}");
            }

            return teachers;
        }

        public void SaveTeachers(List<Teacher> teachers)
        { 
            string serialized = JsonSerializer.Serialize(teachers);
            
            File.WriteAllText(GetTeacherPAth(), serialized);
        }

        public void ClearFile()
        {
            File.WriteAllText(GetTeacherPAth(), string.Empty);
            Console.WriteLine("File cleared successfully.");
        }
       
    }
}

