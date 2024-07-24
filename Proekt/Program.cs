



using Proekt.Services;

public static class Program
{

    static void Main(string[] args)
    {
        

        var schoolService = new SchoolService();
        //string teacherJsonPath = @"C:\Jsonfile\teachers.json";
        //string specialistJsonPath = @"C:\Jsonfile\Specialists.json";
        //schoolService.LoadData(teacherJsonPath, specialistJsonPath);
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
            "Attach Teacher,Group and Room",
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
                        schoolService.GetSpecialists(@"C:\Jsonfile\Specialists.json");
                        schoolService.GetTeachers();
                        Console.Write("Enter Teacher Id: ");
                        var attTId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Specialist Id: ");
                        var attSId = int.Parse(Console.ReadLine());
                        schoolService.AttachSpecialistToTeacher(attTId, attSId);
                        Console.WriteLine("Successfully added!");
                        break;
                    case 6:
                        schoolService.GetTeachers();
                        schoolService.GetRooms(@"C:\Jsonfile\rooms.json");
                        schoolService.GetGroups(@"C:\Jsonfile\groups.json");
                        Console.Write("Enter Teacher Id: ");
                        var addtId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Room Id: ");
                        var addrId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Group Id: ");
                        var addgId =int.Parse(Console.ReadLine());
                        Console.Write("Enter start lesson time(00:00): ");
                        var ontime = Console.ReadLine();
                        Console.Write("Enter end lesson time(00:00): ");
                        var endtime = Console.ReadLine();
                        Console.Write("Day: ");
                        var day = Console.ReadLine();
                        schoolService.Exam(addtId, addrId, addgId, ontime, endtime, day);
                        Console.WriteLine("Successfully added!");
                        break;
                    case 7:
                        schoolService.GetList();
                        break;
                    case 8:
                        schoolService.GetBigList();
                        break;
                    case 9:
                        exit = true;
                        schoolService.ClearFile();
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
            "Clear File",
            "Back to main menu"
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
                        schoolService.AddSpecialist(@"C:\Jsonfile\Specialists.json");
                        break;
                    case 1:
                        schoolService.UpdateSpecialist(@"C:\Jsonfile\Specialists.json");
                        break;
                    case 2:
                        schoolService.DeleteSpecialist(@"C:\Jsonfile\Specialists.json");
                        break;
                    case 3:
                        schoolService.GetSpecialists(@"C:\Jsonfile\Specialists.json");
                        break;
                    case 4:
                        schoolService.ClearFile();
                        break;
                    case 5:
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
        string jsonPath = @"C:\Jsonfile\teachers.json";


        List<string> teacherOptions = new List<string>
        {
            "Add Teacher",
            "List Teachers",
            "Update Teacher",
            "Delete Teacher",
            "Clear Teachers",
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
                        schoolService.AddTeacher();
                        break;
                    case 1:
                        schoolService.GetTeachers();
                        break;
                    case 2:
                        schoolService.UpdateTeacher();
                        break;
                    case 3:
                        schoolService.DeleteTeacher();
                        break;
                    case 4:
                        schoolService.ClearFile();
                        break;
                    case 5:
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
        string jsonPath = @"C:\Jsonfile\students.json";
        Directory.CreateDirectory(Path.GetDirectoryName(jsonPath));

        List<string> students = new List<string>
        {
            "Add Student",
            "Update Student",
            "List Students",
            "Delete Student",
            "Clear Student",
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
                selectedIndex = (selectedIndex - 1 + students.Count) % students.Count;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                switch (selectedIndex)
                {
                    case 0:
                        schoolService.AddStudent(@"C:\Jsonfile\students.json");
                        break;
                    case 1:
                        schoolService.GetStudents(@"C:\Jsonfile\students.json");
                        break;
                    case 2:
                        schoolService.UpdateStudent(@"C:\Jsonfile\students.json");
                        break;
                    case 3:
                        schoolService.DeleteStudent(@"C:\Jsonfile\students.json");
                        break;
                    case 4:
                        schoolService.ClearFile();
                        break;
                    case 5:
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
        string jsonPath = @"C:\Jsonfile\rooms.json";
        Directory.CreateDirectory(Path.GetDirectoryName(jsonPath));

        List<string> rooms = new List<string>
        {
            "Add Room",
            "List Rooms",
            "Update Room",
            "Delete Room",
            "clear file",
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
                        schoolService.AddRoom(@"C:\Jsonfile\rooms.json");
                        break;
                    case 1:
                        schoolService.GetRooms(@"C:\Jsonfile\rooms.json");
                        break;
                    case 2:
                        schoolService.UpdateRoom(@"C:\Jsonfile\rooms.json");
                        break;
                    case 3:
                        schoolService.DeleteRoom(@"C:\Jsonfile\rooms.json");
                        break;
                    case 4:
                        schoolService.ClearFile();
                        break;
                    case 5:
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
        string jsonPath = @"C:\Jsonfile\groups.json";
        Directory.CreateDirectory(Path.GetDirectoryName(jsonPath));

        List<string> groups = new List<string>
        {
            "Add Group",
            "List Groups",
            "Update Group",
            "Delete Group",
            "Clear File",
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
                        schoolService.AddGroup(@"C:\Jsonfile\groups.json");
                        break;
                    case 1:
                        schoolService.GetGroups(@"C:\Jsonfile\groups.json");
                        break;
                    case 2:
                        schoolService.UpdateGroup(@"C:\Jsonfile\groups.json");
                        break;
                    case 3:
                        schoolService.DeleteGroup(@"C:\Jsonfile\groups.json");
                        break;
                    case 4:
                        schoolService.ClearFile();
                        break;
                    case 5:
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

