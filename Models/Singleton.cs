using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Singleton
    {
        public static string GetTeacherPAth()
        {
            string currentPath = Directory.GetCurrentDirectory();
            currentPath += @"C:\Jsonfile\teachers.json";
            return currentPath;
        }
        public static string GetStudentPAth()
        {
            string currentPath = Directory.GetCurrentDirectory();
            currentPath += @"C:\Jsonfile\students.json";
            return currentPath;
        }
        public static string GetRoomPAth()
        {
            string currentPath = Directory.GetCurrentDirectory();
            currentPath += @"C:\Jsonfile\rooms.json";
            return currentPath;
        }
    }
}
