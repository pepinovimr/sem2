using Microsoft.AspNetCore.Mvc;

namespace vosplzen.sem2h1.Data.DTOs
{
    public class JsonResponse
    {
        public int succeded;
        public int failed;

        public ICollection<StudentResponseDTO> students;

        public JsonResponse(int succeded, int failed, ICollection<StudentResponseDTO> students)
        {
            this.succeded = succeded;
            this.failed = failed;
            this.students = students;
        }
    }
}
