using Microsoft.AspNetCore.Mvc;
using vosplzen.sem2h1.Data;
using vosplzen.sem2h1.Data.DTOs;
using vosplzen.sem2h1.Data.Mappers;
using vosplzen.sem2h1.Data.Model;

namespace vosplzen.sem2h1.Services
{
    public class StudentService : IStudentService
    {
        private ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {

            _context = context;
        }

        public IActionResult GetFirstStudent()
        {
            var result = _context.Students.FirstOrDefault();
            return new JsonResult(result);
        }

        public IActionResult GetStudents()
        {
            var result = _context.Students.ToList();
            return new JsonResult(result);
        }

        public IActionResult GetTopStudents(int topCount, string? orderBy = "surname")
        {

            if (orderBy == "name")
            {
                return new JsonResult(_context.Students.Take(topCount).OrderBy(x => x.Name).ToList());
            }
            else
            {

                return new JsonResult(_context.Students.Take(topCount).OrderBy(x => x.Surname).ToList());
            }
        }

        public IActionResult PostStudents(List<StudentDTO> studentDTOs)
        {
            List<Student> insertedStudents = new();

            foreach (var studentDTO in studentDTOs)
            {
                if (ObjectPropertyHelper.isAnyPropertyNull(studentDTO._id, studentDTO.name, studentDTO.about, studentDTO.email))
                    continue;

                if (!_context.Students.Any(x => x.ExternalId == studentDTO._id))
                {
                    var stud = StudentMapper.StudentDTOToStudent(studentDTO);

                    _context.Students.Add(stud);

                    insertedStudents.Add(stud);
                }
            }
            _context.SaveChanges();

            var addedStudents = StudentMapper.StudentsToStudentResponseDTOs(insertedStudents);

            JsonResponse response = new JsonResponse
                (addedStudents.Count(), studentDTOs.Count() - addedStudents.Count(), addedStudents);


            return new JsonResult(response);
        }
    }
}
