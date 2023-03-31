using System.ComponentModel.DataAnnotations;

namespace vosplzen.sem2h1.Data.DTOs
{
    public class StudentDTO
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string about { get; set; }
    }
}
