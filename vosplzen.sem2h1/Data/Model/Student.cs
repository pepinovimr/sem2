using System.ComponentModel.DataAnnotations;

namespace vosplzen.sem2h1.Data.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ExternalId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string About { get; set; }
    }
}
