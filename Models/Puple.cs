namespace Models
{
    public class Puple
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Number { get; set; }
        public List<Group> Grouplist { get; set; }
        public List<Booking> Bookinglist { get; set; } = new List<Booking>();
    }
}
