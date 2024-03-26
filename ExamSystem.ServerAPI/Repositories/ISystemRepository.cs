using System.Collections.Generic;
using System.Threading.Tasks;
using ExamSystem.ServerAPI.DbModels;
using ExamSystem.ServerAPI.Models;

namespace ExamSystem.ServerAPI.Repositories
{
    public interface ISystemRepository
    {
        // User-related methods
        Task<bool> UserRegister(User user);
        Task<User> GetUserByUserId(string userId);
        Task<User> ValidateUser(string password, string userId);
        Task<List<User>> GetAllUsers();

        // Exam-related methods
        Task<List<Exam>> GetAllExams();
        Task<Exam> GetExamById(int id);
        Task<bool> CreateExam(Exam exam);
        Task<bool> UpdateExam(Exam updatedExam);
        Task<List<Exam>> GetExamsByCourseType(Course_Enum courseType);
        Task<bool> DeleteExam(int id);

        // Participation-related methods
        Task<List<Participation>> GetAllParticipations();
        Task<List<Participation>> GetAllParticipationsById(int examId);
        Task<Participation> GetParticipationById(int id);
        Task<bool> CreateParticipation(Participation participation);
        Task<bool> UpdateParticipation(Participation updatedParticipation);
        Task<bool> DeleteParticipation(int id);
        Task<bool> GetByStudentAndExamId(string studentId, int examId);
        Task<Participation> GetParticipationBySE(string studentId, int examId);
    }
}
