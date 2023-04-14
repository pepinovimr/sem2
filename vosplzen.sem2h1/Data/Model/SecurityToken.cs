using System.ComponentModel.DataAnnotations;

namespace vosplzen.sem2h1.Data.Model
{
    public class SecurityToken
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        public DateTime ValidUntil { get; set; }
    }
}
