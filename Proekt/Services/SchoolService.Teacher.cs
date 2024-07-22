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
        public void AddTeacher(string jsonPath)
        {
            List<Teacher> teachers = GetTeachers(jsonPath);

            Console.Write("Enter Teacher Name: ");
            string teacherName = Console.ReadLine();

            int newId = teachers.Count > 0 ? teachers.Max(t => t.Id) + 1 : 1;

            Teacher newTeacher = new Teacher
            {
                Id = newId,
                Name = teacherName
            };

            teachers.Add(newTeacher);
            SaveTeachers(jsonPath, teachers);

            Console.WriteLine("Teacher added successfully.");
        }

        public void UpdateTeacher(string jsonPath)
        {
            List<Teacher> teachers = GetTeachers(jsonPath);

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

            SaveTeachers(jsonPath, teachers);
            Console.WriteLine("Teacher updated successfully.");
        }

        public void DeleteTeacher(string jsonPath)
        {
            List<Teacher> teachers = GetTeachers(jsonPath);

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
            SaveTeachers(jsonPath, teachers);

            Console.WriteLine("Teacher deleted successfully.");
        }

        public List<Teacher> GetTeachers(string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                return new List<Teacher>();
            }

            string jsonFromFile = File.ReadAllText(jsonPath);
            var teachers = string.IsNullOrEmpty(jsonFromFile) ? new List<Teacher>() : JsonSerializer.Deserialize<List<Teacher>>(jsonFromFile);

            Console.WriteLine("Teachers List:");
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"Id: {teacher.Id}, Name: {teacher.Name}");
            }

            return teachers;
        }

        public void SaveTeachers(string jsonPath, List<Teacher> teachers)
        {
            string serialized = JsonSerializer.Serialize(teachers);
            File.WriteAllText(jsonPath, serialized);
        }

        public void ClearFile(string jsonPath)
        {
            File.WriteAllText(jsonPath, string.Empty);
            Console.WriteLine("File cleared successfully.");
        }
    }
}


        //public void UpdateTeacher (int id, string? name)
        //{
        //    var teacher = teachers.FirstOrDefault(f => f.Id == id);
        //    if (teacher != null)
        //    {
        //        teacher.Name = name;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Teacher not Found!");
        //    }
        //}
        //public void DeleteTeacher(int id)
        //{
        //    var teacher = teachers.FirstOrDefault(f => f.Id == id);
        //    if (teacher != null)
        //    {
        //        teachers.Remove(teacher);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Teacher Not Found!");
        //    }
        //}
        //public void ListTeachers()
        //{
        //    foreach (var teacher in teachers)
        //    {
        //        Console.WriteLine($"TeacherId: {teacher.Id}, Name: {teacher.Name}");
        //    }
        //}
//    }
//}

