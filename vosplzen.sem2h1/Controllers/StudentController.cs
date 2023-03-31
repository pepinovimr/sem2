using MethodTimer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using vosplzen.sem2h1.Data;
using vosplzen.sem2h1.Data.DTOs;
using vosplzen.sem2h1.Data.Mappers;
using vosplzen.sem2h1.Data.Model;

namespace vosplzen.sem2h1.Controllers
{

    [ApiController]
    [Route("Students")]
    public class StudentController : Controller
    {

        private ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context) {

            _context = context;
        }
        
        [HttpGet]
        [Route("List")]
        public IActionResult Getlist()
        {

            var result = _context.Students.ToList();
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("First")]
        public IActionResult GetFirst()
        {

            var result = _context.Students.FirstOrDefault();
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("Top")]
        public IActionResult GetTop(int topCount, string? orderBy = "surname") {
            
            if(topCount <= 0) { return BadRequest(); }

            if (orderBy == "name")
            {
                return new JsonResult(_context.Students.Take(topCount).OrderBy(x => x.Name).ToList());
            }
            else {

                return new JsonResult(_context.Students.Take(topCount).OrderBy(x => x.Surname).ToList());
            }
        }

        
        [HttpPost]
        [Route("Add")]
        [Time]
        public IActionResult PostStudents(List<StudentDTO> studentDTOs)
        {
            List<Student> insertedStudents = new();

            foreach (var studentDTO in studentDTOs)
            {
                if (ObjectPropertyHelper.isAnyPropertyNull(studentDTO._id, studentDTO.name, studentDTO.about, studentDTO.email))
                    continue;

                if(!_context.Students.Any(x => x.ExternalId == studentDTO._id))
                {
                    var stud = StudentMapper.StudentDTOToStudent(studentDTO);

                    _context.Students.Add(stud);

                    insertedStudents.Add(stud);
                }
            }
            var addedStudents = StudentMapper.StudentsToStudentResponseDTOs(insertedStudents);

            JsonResponse response = new JsonResponse()
            {
                students = addedStudents,
                succeded = addedStudents.Count(),
                failed = studentDTOs.Count() - addedStudents.Count()
            };

            _context.SaveChanges();

            return new JsonResult(response);
        }
        //3078ms

    }
}
