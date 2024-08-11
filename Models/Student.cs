using System.ComponentModel.DataAnnotations;
namespace Registrar;

    public class Student
    {
        
        private static Random random = new Random();
        public int Id { get; } = random.Next(100000, 999999);
        
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Student type is required.")]
        public string Type { get; set; } // "Full Time", "Part Time", or "Coop"
        public List<Course> Courses { get; set; } = new List<Course>();
    }

