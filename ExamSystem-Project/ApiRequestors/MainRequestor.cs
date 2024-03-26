using ExamSystem_Project.Helpers;
using ExamSystem_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExamSystem_Project.ApiRequestors
{
    public class MainRequestor
    {
        bool isOkResponse;
        List<object> objResponse;

        readonly HttpClient httpClient;


        public MainRequestor() : this("https://localhost:7076/")
        {
            isOkResponse = false;
        }
        public MainRequestor(string apiUrl)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(apiUrl);
        }

        public async Task<bool> Request_NewPost<T>(T obj, string apiStr)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize<T>(obj);

                using StringContent dataContent = new StringContent(jsonData, Encoding.UTF8, @"application/json");

                using HttpResponseMessage response = await httpClient.PostAsync(apiStr, dataContent);

                response.EnsureSuccessStatusCode(); // 201

                bool isOkResponse = await response.Content.ReadFromJsonAsync<bool>();

                return isOkResponse;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<T> Request_GetById<T>(string strId, string apiStr)
        {
            try
            {
                using HttpResponseMessage response = await httpClient.GetAsync($"{apiStr}/{strId}");

                response.EnsureSuccessStatusCode(); // 201

                // Get Json Data From Server Result
                T obj = await response.Content.ReadFromJsonAsync<T>();

                return obj;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<User> Request_LoginAsync(User credentials)
        {
            try
            {
                //3.1) Convert credentials Object to JSON
                string jsonLoginData = JsonSerializer.Serialize<User>(credentials);
                using StringContent LoginContent = new StringContent(jsonLoginData, Encoding.UTF8, @"application/json");

                //3.2 Get response 
                using HttpResponseMessage response =
                    await httpClient.PostAsync("api/users/login", LoginContent);

                response.EnsureSuccessStatusCode();//201

                //3.3 Get Json Data From Server Result
                User userResponse =
                    await response.Content.ReadFromJsonAsync<User>();

                return userResponse;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<List<Exam>> Request_GetExamsByCourseType(Course_Enum courseType)
        {
            try
            {
                // Get exams by course type
                List<Exam> exams = await httpClient.GetFromJsonAsync<List<Exam>>($"api/exams/getbycoursetype/{courseType}");

                return exams;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> Request_GetByStudentAndExamId(string studentId, int examId)
        {
            try
            {
                UriBuilder builder = new UriBuilder(httpClient.BaseAddress);
                builder.Path = "api/participations/bystudentandexam";
                builder.Query = $"studentId={studentId}&examId={examId}";

                return await httpClient.GetFromJsonAsync<bool>(builder.Uri.ToString());
            }
            catch
            {
                return false;
            }
        }


        public async Task<Participation> Request_GetParticipationBySE(string studentId, int examId)
        {
            try
            {
                UriBuilder builder = new UriBuilder(httpClient.BaseAddress);
                builder.Path = "api/participations/getparticipationbyse";
                builder.Query = $"studentId={studentId}&examId={examId}";

                return await httpClient.GetFromJsonAsync<Participation>(builder.Uri.ToString());
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<T>> Request_GetAll<T>(string apiStr)
        {
            try
            {
                // Get response
                using HttpResponseMessage response = await httpClient.GetAsync(apiStr);

                response.EnsureSuccessStatusCode(); // 201



                // Get Json Data From Server Result
                List<T> objList = await response.Content.ReadFromJsonAsync<List<T>>();




                return objList;
            }
            catch (Exception ex)
            {
                throw; // Return false in case of an exception.
            }
        }


        public async Task<List<Participation>> Request_GetAllById(int id)
        {
            try
            {

                using HttpResponseMessage response = await httpClient.GetAsync($"api/participations/getallparticipationsbyexamid/{id}");

                response.EnsureSuccessStatusCode(); // 201

                List<Participation> participations = await response.Content.ReadFromJsonAsync<List<Participation>>();


                return participations;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public async Task<bool> Request_Put<T>(T obj, string apiStr)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize<T>(obj);

                using StringContent dataContent = new StringContent(jsonData, Encoding.UTF8, @"application/json");

                using HttpResponseMessage response = await httpClient.PutAsync(apiStr, dataContent);

                response.EnsureSuccessStatusCode(); // 200 OK

                // Get Json Data From Server Result
                bool isOkResponse = await response.Content.ReadFromJsonAsync<bool>();

                return isOkResponse;
            }
            catch (Exception ex)
            {
                throw;
            }




        }


        public async Task<bool> Request_Delete(string strId, string apiStr)
        {
            try
            {
                using HttpResponseMessage response = await httpClient.DeleteAsync($"{apiStr}/{strId}");

                response.EnsureSuccessStatusCode(); // 200 OK

                // Get Json Data From Server Result
                bool isOkResponse = await response.Content.ReadFromJsonAsync<bool>();

                return isOkResponse;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}
