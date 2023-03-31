using vosplzen.sem2h1.Data.DTOs;
using vosplzen.sem2h1.Data.Model;

namespace vosplzen.sem2h1.Data.Mappers
{
    public static class StudentMapper
    {
        public static Student StudentDTOToStudent(StudentDTO student)
        {
            var names = student.name.Split(' ');

            Student newStudent = new Student()
            {
                ExternalId = student._id,
                Name = String.Join(' ',names.SkipLast(1)),
                Surname = names.Last(),
                Email = student.email,
                About = student.about
            };

            return newStudent;
        }

        public static List<Student> StudentDTOsToStudents(List<StudentDTO> students)
        {
            List<Student> newStudents = new ();

            foreach (var student in students)
            {
                newStudents.Add(StudentDTOToStudent(student));
            }

            return newStudents;
        }

        public static StudentResponseDTO StudentToStudentResponseDTO(Student student)
        {
            var output = new StudentResponseDTO()
            {
                Id = student.Id,
                ExternalId = student.ExternalId
            };

            return output;
        }

        public static List<StudentResponseDTO> StudentsToStudentResponseDTOs(List<Student> students)
        {
            List<StudentResponseDTO> newStudents = new();

            foreach (var student in students)
            {
                newStudents.Add(StudentToStudentResponseDTO(student));
            }

            return newStudents;
        }
    }
}
