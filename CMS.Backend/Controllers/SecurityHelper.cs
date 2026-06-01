using System.Security.Cryptography;
using System.Text;

namespace CMS.Backend.Helpers
{
    public static class SecurityHelper
    {
        public static string HashPassword(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString(); // Trả về chuỗi mật khẩu đã mã hóa dài 32 ký tự
            }
        }
    }
}