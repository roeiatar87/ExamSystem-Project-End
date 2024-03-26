using ExamSystem.ServerAPI.Models;
using System.Security.Cryptography;
using System.Text;

namespace ExamSystem.ServerAPI.Services
{
    public class MD5Convertor
    {
        
       
        public static string GetMd5Hash(string st)
        {
            try
            {
                using (MD5 md5 = MD5.Create())
                {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(st);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    // Convert the byte array to a hexadecimal string
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString("x2"));
                    }

                    return sb.ToString();
                }
            }
            catch (Exception)
            {

                return null;
            }
    
        }
    }
}
