using Microsoft.AspNetCore.Mvc;
using vosplzen.sem2h1.Data.DTOs;

namespace vosplzen.sem2h1.Services
{
    public interface IStudentService
    {
        public IActionResult GetStudents();

        public IActionResult GetFirstStudent();

        public IActionResult GetTopStudents(int topCount, string? orderBy = "surname");

        public IActionResult PostStudents(List<StudentDTO> studentDTOs);
    }
}
