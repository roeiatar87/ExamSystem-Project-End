using ExamSystem.ServerAPI.DbModels;
using ExamSystem.ServerAPI.Models;
using ExamSystem.ServerAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace ExamSystem.ServerAPI.Repositories
{
    public class SystemRepository : ISystemRepository
    {

        private readonly AppDbContext _context;

        public SystemRepository(AppDbContext context)
        {
            _context = context;
        }

        #region Users
        public async Task<bool> UserRegister(User user)
        {
            user.PassWord = MD5Convertor.GetMd5Hash(user.PassWord);
            _context.Users.Add(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User> GetUserByUserId(string userId)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            if (user == null)
            {
                return new User();
            }

            return user;
        }

        public async Task<User> ValidateUser(string password, string userId)
        {
            string convertedPass = MD5Convertor.GetMd5Hash(password);
            return await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId && x.PassWord == convertedPass);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
        #endregion

        #region Exams
        public async Task<List<Exam>> GetAllExams()
        {
            List<Exam> exams = await _context.Exams
                .Include(e => e.questions)
                    .ThenInclude(q => q.Options)
                .ToListAsync();

            return exams;
        }

        public async Task<Exam> GetExamById(int id)
        {


            var exam = await _context.Exams
           .Include(e => e.questions)
           .ThenInclude(q => q.Options)
           .FirstOrDefaultAsync(e => e.ExamId == id);

            return exam;
        }

        public async Task<bool> CreateExam(Exam exam)
        {
            try
            {
                _context.Exams.Add(exam);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                return false;
            }
        }

        public async Task<bool> UpdateExam(Exam updatedExam)
        {
            try
            {
                _context.Exams.Update(updatedExam);
                return await _context.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<List<Exam>> GetExamsByCourseType(Course_Enum courseType)
        {
            var exam = await _context.Exams
                .Include(e => e.questions)
                    .ThenInclude(q => q.Options)
                .Where(e => e.CourseType == courseType)
                .ToListAsync();

            return exam;
        }

        public async Task<bool> DeleteExam(int id)
        {
            var examToDelete = await _context.Exams
                .Include(e => e.questions)
                .ThenInclude(q => q.Options)
                .FirstOrDefaultAsync(e => e.ExamId == id);

            if (examToDelete != null)
            {
                // Manually remove options associated with questions
                foreach (var question in examToDelete.questions)
                {
                    _context.OptionAns.RemoveRange(question.Options);
                }

                // Manually remove questions associated with the exam
                _context.Questions.RemoveRange(examToDelete.questions);

                // Remove the exam itself
                _context.Exams.Remove(examToDelete);

                // Save changes to the database
                return await _context.SaveChangesAsync() > 0;
            }

            return false;
        }


        #endregion

        #region Participations
        public async Task<List<Participation>> GetAllParticipations()
        {
            try
            {
                List<Participation> participations = await _context.Participations.ToListAsync();
                return participations;
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public async Task<List<Participation>> GetAllParticipationsById(int examId)
        {
            try
            {
                // Retrieve participations filtered by examId
                List<Participation> participations = await _context.Participations
                    .Where(p => p.Exam_Id == examId)
                    .ToListAsync();

                // Loop through each participation to retrieve errors
                foreach (var participation in participations)
                {
                    participation.errors = await _context.Errors
                        .Where(e => e.ParticipationId == participation.ParticipationId)
                        .ToListAsync();
                }


                return participations;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // Returning null might not be the best practice; consider throwing the exception instead
                return null;
            }
        }
        public async Task<Participation> GetParticipationById(int id)
        {
            try
            {

                var participation = await _context.Participations.FirstOrDefaultAsync(p => p.Exam_Id == id);

                if (participation != null)
                {
                    participation.errors = await _context.Errors.Where(e => e.ParticipationId == participation.ParticipationId).ToListAsync();
                }

                if (participation == null)
                {
                    return new Participation();
                }

                return participation;
            }
            catch (Exception ex)
            {

                return new Participation();
            }

        }

        public async Task<bool> CreateParticipation(Participation participation)
        {
            try
            {
                _context.Participations.Add(participation);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                return false;
            }
        }

        public async Task<bool> UpdateParticipation(Participation updatedParticipation)
        {
            try
            {
                _context.Participations.Update(updatedParticipation);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                return false;
            }
        }

        public async Task<bool> DeleteParticipation(int id)
        {
            try
            {
                var participationToDelete = await _context.Participations.FindAsync(id);
                if (participationToDelete != null)
                {
                    _context.Participations.Remove(participationToDelete);
                    return await _context.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {

                return false;
            }


        }

        public async Task<bool> GetByStudentAndExamId(string studentId, int examId)
        {
            try
            {
                return await _context.Participations
          .AnyAsync(p => p.Student_Id == studentId && p.Exam_Id == examId);
            }
            catch (Exception ex)
            {
                return false;

            }

        }

        public async Task<Participation> GetParticipationBySE(string studentId, int examId)
        {
            try
            {
                Participation participation = await _context.Participations.FirstOrDefaultAsync(p => p.Student_Id == studentId && p.Exam_Id == examId);

                // Assuming you intended to retrieve errors associated with the participation, you should include that logic
                if (participation != null)
                {
                    participation.errors = await _context.Errors.Where(e => e.ParticipationId == participation.ParticipationId).ToListAsync();
                }

                return participation;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return null;
            }
        }
        #endregion

    }
}
