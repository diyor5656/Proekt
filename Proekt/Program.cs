
using System;
using System.Collections.Generic;
using Proekt.Services;

public static class Program
{
    static void Main(string[] args)
    {
        var schoolService = new SchoolService();
        bool exit = false;
        int selectedIndex = 0;

        
        List<string> Buyruqlar = new List<string>
        {
            "Specialist",
            "Teacher",
            "Student",
            "Room",
            "Group",
            "Attach Specialist to Teacher",
            "Attach Teacher,Group and Room ",
            "Get teacher's expertise List",
            "Get All lists",
            "Exit"
        };

        while (!exit)
        {
            Console.Clear();
            for (int i = 0; i < Buyruqlar.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(Buyruqlar[i]);
                Console.ResetColor();
            }

            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.DownArrow)
            {
                selectedIndex = (selectedIndex + 1) % Buyruqlar.Count;
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                selectedIndex = (selectedIndex - 1 + Buyruqlar.Count) % Buyruqlar.Count;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                switch (selectedIndex)
                {
                    case 0: 
                        SpecialistMenu(schoolService);
                        break;
                    case 1: 
                        TeacherMenu(schoolService);
                        break;
                    case 2: 
                        StudentMenu(schoolService);
                        break;
                    case 3: 
                        RoomMenu(schoolService);
                        break;
                    case 4: 
                        GroupMenu(schoolService);
                        break;
                    case 5:
                        schoolService.ListSpecialists();
                        schoolService.ListTeachers();
                        Console.Write("Enter Teacher Id: ");
                        var attTId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Specialist Id: ");
                        var attSId = int.Parse(Console.ReadLine());
                        schoolService.AttachSpecialistToTeacher(attTId, attSId);
                        Console.WriteLine("Successfully addet!.");
                        break;
                    case 6:
                        schoolService.ListTeachers();
                        schoolService.ListRoom();
                        schoolService.ListGroup();
                        Console.Write("Enter Teacher Id: ");
                        var addtId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Room Id: ");
                        var addrId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Group Id: ");
                        var addgId = int.Parse(Console.ReadLine());
                        schoolService.Booking(addtId, addrId,addgId);
                        Console.WriteLine("Successfully addet!.");
                        break;
                    case 7: 
                        schoolService.GetList();
                        break;
                    case 8: 
                        schoolService.GetBigList();
                        break;
                    case 9: 
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Error, please try again.");
                        break;
                }

                Console.ReadKey(); 
            }
        }
    }

    static void SpecialistMenu(SchoolService schoolService)
    {
        bool exit = false;
        int selectedIndex = 0;

        List<string> specialistss = new List<string>
        {
            "Add Specialist",
            "Update Specialist",
            "Delete Specialist",
            "List Specialists",
            "Back to Main Menu"
        };

        while (!exit)
        {
            Console.Clear();
            for (int i = 0; i < specialistss.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(specialistss[i]);
                Console.ResetColor();
            }

            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.DownArrow)
            {
                selectedIndex = (selectedIndex + 1) % specialistss.Count;
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                selectedIndex = (selectedIndex - 1 + specialistss.Count) % specialistss.Count;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                switch (selectedIndex)
                {
                    case 0: 
                        Console.Write("Enter Specialist Name: ");
                        var sName = Console.ReadLine();
                        Console.Write("Enter Specialist Stack: ");
                        var stack = Console.ReadLine();
                        schoolService.AddSpecialist(sName, stack);
                        Console.WriteLine("Successfully added.");
                        break;
                    case 1:
                        Console.Write("Enter Specialist Id: ");
                        var sId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Specialist Name: ");
                        var newSName = Console.ReadLine();
                        Console.Write("Enter Specialist Stack: ");
                        var newStack = Console.ReadLine();
                        schoolService.UpdateSpecialist(sId, newSName, newStack);
                        Console.WriteLine("Successfully updated.");
                        break;
                    case 2:
                        Console.Write("Enter Specialist Id: ");
                        var deleteSId = int.Parse(Console.ReadLine());
                        schoolService.DeleteSpecialist(deleteSId);
                        Console.WriteLine("Successfully deleted.");
                        break;
                    case 3: 
                        schoolService.ListSpecialists();
                        break;
                    case 4: 
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

                Console.ReadKey(); 
            }
        }
    }

    static void TeacherMenu(SchoolService schoolService)
    {
        bool exit = false;
        int selectedIndex = 0;

        List<string> teacherOptions = new List<string>
        {
            "Add Teacher",
            "Update Teacher",
            "Delete Teacher",
            "List Teachers",
            "Back to Main Menu"
        };

        while (!exit)
        {
            Console.Clear();
            for (int i = 0; i < teacherOptions.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(teacherOptions[i]);
                Console.ResetColor();
            }

            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.DownArrow)
            {
                selectedIndex = (selectedIndex + 1) % teacherOptions.Count;
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                selectedIndex = (selectedIndex - 1 + teacherOptions.Count) % teacherOptions.Count;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                switch (selectedIndex)
                {
                    case 0: 
                        Console.Write("Enter Teacher Name: ");
                        var tName = Console.ReadLine();
                        schoolService.AddTeacher(tName);
                        Console.WriteLine("Successfully added.");
                        break;
                    case 1:
                        Console.Write("Enter Teacher Id: ");
                        var tId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Teacher Name: ");
                        var newTName = Console.ReadLine();
                        schoolService.UpdateTeacher(tId, newTName);
                        Console.WriteLine("Successfully updated.");
                        break;
                    case 2:
                        Console.Write("Enter Teacher Id: ");
                        var deleteTId = int.Parse(Console.ReadLine());
                        schoolService.DeleteTeacher(deleteTId);
                        Console.WriteLine("Successfully deleted.");
                        break;
                    case 3: 
                        schoolService.ListTeachers();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

                Console.ReadKey(); 
            }
        }
    }

    static void StudentMenu(SchoolService schoolService)
    {
        bool exit = false;
        int selectedIndex = 0;

        List<string> students = new List<string>
        {
            "Add Student",
            "Update Student",
            "Delete Student",
            "List Student",
            "Back to Main Menu"
        };

        while (!exit)
        {
            Console.Clear();
            for (int i = 0; i < students.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(students[i]);
                Console.ResetColor();
            }

            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.DownArrow)
            {
                selectedIndex = (selectedIndex + 1) % students.Count;
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                selectedIndex = (selectedIndex - 1 + students.Count) %  students.Count;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                switch (selectedIndex)
                {
                    case 0:
                        Console.Write("Enter Student Name: ");
                        var sName = Console.ReadLine();
                        schoolService.AddStudent(sName);
                        Console.WriteLine("Successfully added.");
                        break;
                    case 1:
                        Console.Write("Enter Student Id: ");
                        var sId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Student Name: ");
                        var newSName = Console.ReadLine();
                        schoolService.UpdateStudent(sId, newSName);
                        Console.WriteLine("Successfully updated.");
                        break;
                    case 2:
                        Console.Write("Enter Student Id: ");
                        var deleteSId = int.Parse(Console.ReadLine());
                        schoolService.DeleteStudent(deleteSId);
                        Console.WriteLine("Successfully deleted.");
                        break;
                    case 3:
                        schoolService.ListStudents();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

                Console.ReadKey();
            }
        }
    }

    static void RoomMenu(SchoolService schoolService)
    {
        bool exit = false;
        int selectedIndex = 0;

        List<string> rooms = new List<string>
    {
        "Add Room",
        "Update Room",
        "Delete Room",
        "List Rooms",
        "Back to Main Menu"
    };

        while (!exit)
        {
            Console.Clear();
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(rooms[i]);
                Console.ResetColor();
            }

            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.DownArrow)
            {
                selectedIndex = (selectedIndex + 1) % rooms.Count;
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                selectedIndex = (selectedIndex - 1 + rooms.Count) % rooms.Count;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                switch (selectedIndex)
                {
                    case 0:
                        Console.Write("Enter Room Name: ");
                        var rName = Console.ReadLine();
                        schoolService.AddRoom(rName);
                        Console.WriteLine("Successfully added.");
                        break;
                    case 1:
                        Console.Write("Enter Room Id: ");
                        var rId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Room Name: ");
                        var newRName = Console.ReadLine();
                        schoolService.UpdateRoom(rId, newRName);
                        Console.WriteLine("Successfully updated.");
                        break;
                    case 2:
                        Console.Write("Enter Room Id: ");
                        var deleteRId = int.Parse(Console.ReadLine());
                        schoolService.DeleteRoom(deleteRId);
                        Console.WriteLine("Successfully deleted.");
                        break;
                    case 3:
                        schoolService.ListRoom();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

                Console.ReadKey();
            }
        }
    }

    static void GroupMenu(SchoolService schoolService)
    {
        bool exit = false;
        int selectedIndex = 0;

        List<string> groups = new List<string>
    {
        "Add Group",
        "Update Group",
        "Delete Group",
        "List Groups",
        "Back to Main Menu"
    };

        while (!exit)
        {
            Console.Clear();
            for (int i = 0; i < groups.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(groups[i]);
                Console.ResetColor();
            }

            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.DownArrow)
            {
                selectedIndex = (selectedIndex + 1) % groups.Count;
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                selectedIndex = (selectedIndex - 1 + groups.Count) % groups.Count;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                switch (selectedIndex)
                {
                    case 0:
                        Console.Write("Enter Group Name: ");
                        var gName = Console.ReadLine();
                        schoolService.AddGroup(gName);
                        Console.WriteLine("Successfully added.");
                        break;
                    case 1:
                        Console.Write("Enter Group Id: ");
                        var gId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Group Name: ");
                        var newGName = Console.ReadLine();
                        schoolService.UpdateGroup(gId, newGName);
                        Console.WriteLine("Successfully updated.");
                        break;
                    case 2:
                        Console.Write("Enter Group Id: ");
                        var deleteGId = int.Parse(Console.ReadLine());
                        schoolService.DeleteGroup(deleteGId);
                        Console.WriteLine("Successfully deleted.");
                        break;
                    case 3:
                        schoolService.ListGroup();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

                Console.ReadKey();
            }
        }
    }

}
