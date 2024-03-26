using ExamSystem.ServerAPI.Models;
using ExamSystem.ServerAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamSystem.ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipationsController : ControllerBase
    {
        private readonly ISystemRepository _participationRepo;

        public ParticipationsController(ISystemRepository repo)
        {
            _participationRepo = repo;
        }

        [HttpGet("getallparticipations")]
        public async Task<List<Participation>> GetAllParticipations()
        {
            return await _participationRepo.GetAllParticipations();
        }

        [HttpGet("getallparticipationsbyexamid/{id}")]
        public async Task<List<Participation>> GetAllParticipationsById(int id)
        {
            return await _participationRepo.GetAllParticipationsById(id);
        }

        [HttpGet("{id}")]
        public async Task<Participation> GetParticipationById(int id)
        {
            return await _participationRepo.GetParticipationById(id);
        }

        [HttpPost("create")]
        public async Task<bool> CreateParticipation([FromBody] Participation participation)
        {
            return await _participationRepo.CreateParticipation(participation);
        }

        [HttpPut("update")]
        public async Task<bool> UpdateParticipation([FromBody] Participation updatedParticipation)
        {
            return await _participationRepo.UpdateParticipation(updatedParticipation);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteParticipation(int id)
        {
            return await _participationRepo.DeleteParticipation(id);
        }

        [HttpGet("bystudentandexam")]
        public async Task<bool> GetByStudentAndExamId(string studentId, int examId)
        {
            return await _participationRepo.GetByStudentAndExamId(studentId, examId);
        }

        [HttpGet("getparticipationbyse")]
        public async Task<Participation> GetParticipationBySE(string studentId, int examId)
        {
            return await _participationRepo.GetParticipationBySE(studentId, examId);
        }
    }
}
