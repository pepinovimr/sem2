using Microsoft.AspNetCore.Mvc;
using vosplzen.sem2h1.Data.DTOs;
using vosplzen.sem2h1.Filters;
using vosplzen.sem2h1.Services;

namespace vosplzen.sem2h1.Controllers
{

    [ApiController]
    [Route("Students")]
    public class StudentController : Controller
    {
        private IStudentService _studentService;

        public StudentController(IStudentService studentService) 
        {
            _studentService = studentService;
        }
        
        [HttpGet]
        [Route("List")]
        public IActionResult GetList()
        {
            return _studentService.GetStudents();
        }

        [HttpGet]
        [Route("First")]
        public IActionResult GetFirst()
        {

            return _studentService.GetFirstStudent();
        }

        [HttpGet]
        [Route("Top")]
        public IActionResult GetTop(int topCount, string? orderBy = "surname") {
            
            if(topCount <= 0) { return BadRequest(); }

            return _studentService.GetTopStudents(topCount, orderBy);
        }

        [IdentityFilter]
        [HttpPost]
        [Route("Add")]
        public IActionResult PostStudents(List<StudentDTO> studentDTOs)
        {
            return _studentService.PostStudents(studentDTOs);
        }
        //3078ms

    }
}
