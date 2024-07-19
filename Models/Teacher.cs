namespace Models;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Gender;
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public List<TeacherSpc> TeacherSpc { get; set; } = new List<TeacherSpc>();
    public List<Booking> Grouplist { get; set; } = new List<Booking>();

}