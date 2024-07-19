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
        private List<Puple> students = new List<Puple>();

        public void AddStudent(string name)
        {
            int id = students.Count > 0 ? students.Max(h => h.Id) + 1 : 1;
            students.Add(new Puple { Id = id, Name = name });
        }
        
        public void DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(t => t.Id == id);
            if (student != null)
            {
                students.Remove(student);
            }
            else
            {
                Console.WriteLine("Teacher not found.");
            }
        }
        public void UpdateStudent(int id, string  name)
        {
            var student = students.FirstOrDefault(t => t.Id == id);
            if (student != null)
            {
                student.Name = name;
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
        public void ListStudents()
        {
            foreach (var student in students)
            {
                Console.WriteLine($"StudentsId: {student.Id}, Name: {student.Name},");
            }
        }
    }
}

