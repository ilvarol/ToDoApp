using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ToDoApp.Core.Extensions
{
    public static class Extensions
    {
        public static string ToMd5Hash(this string password)
        {
            using (var md5 = MD5.Create())
            {
                var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                return string.Concat(bytes.Select(x => x.ToString("x2")));
            }
        }
    }
}
