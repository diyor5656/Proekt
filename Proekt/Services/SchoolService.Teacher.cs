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
       
        public void AddTeacher(string? name)
        {
            int id = teachers.Count > 0 ? teachers.Max(t => t.Id) + 1 : 1;
            teachers.Add(new Teacher { Id = id, Name = name });
        }
        public void UpdateTeacher (int id, string? name)
        {
            var teacher = teachers.FirstOrDefault(f => f.Id == id);
            if (teacher != null)
            {
                teacher.Name = name;
            }
            else
            {
                Console.WriteLine("Teacher not Found!");
            }
        }
        public void DeleteTeacher(int id)
        {
            var teacher = teachers.FirstOrDefault(f => f.Id == id);
            if (teacher != null)
            {
                teachers.Remove(teacher);
            }
            else
            {
                Console.WriteLine("Teacher Not Found!");
            }
        }
        public void ListTeachers()
        {
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"TeacherId: {teacher.Id}, Name: {teacher.Name}");
            }
        }
    }
}

