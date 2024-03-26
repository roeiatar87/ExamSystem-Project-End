using ExamSystem.ServerAPI.Models;
using ExamSystem.ServerAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ExamSystem.ServerAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly ISystemRepository _examsRepo;

        public ExamsController(ISystemRepository repo)
        {
            _examsRepo = repo;
        }

        [HttpGet("getallexams")]
        public async Task<List<Exam>> GetAllExams()
        {
            return await _examsRepo.GetAllExams();
        }

        [HttpGet("{id}")]
        public async Task<Exam> GetExam(int id)
        {
            return await _examsRepo.GetExamById(id);
        }

        [HttpGet("getbycoursetype/{courseType}")]
        public async Task<List<Exam>> GetExamsByCourseType(Course_Enum courseType)
        {
            return await _examsRepo.GetExamsByCourseType(courseType);
        }

        [HttpPost("create")]
        public async Task<bool> CreateExam([FromBody] Exam exam)
        {
            return await _examsRepo.CreateExam(exam);
        }

        [HttpPut("update")]
        public async Task<bool> UpdateExam([FromBody] Exam updatedExam)
        {
            return await _examsRepo.UpdateExam(updatedExam);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteExam(int id)
        {
            return await _examsRepo.DeleteExam(id);
        }
    }
}