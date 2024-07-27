namespace Registrar;

    public class Student
    {
        private static Random random = new Random();
        public int Id { get; } = random.Next(100000, 999999);
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; } // "Full Time", "Part Time", or "Coop"
        public List<Course> Courses { get; set; } = new List<Course>();
    }

