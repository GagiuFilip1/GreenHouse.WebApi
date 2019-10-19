using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Encoder
{
    public class ShaEncoder
    {
        public static async Task<string> Encode(string value)
        {
            using var sha256Hash = SHA256.Create();
            var builder = new StringBuilder(); 
            await Task.Factory.StartNew(() =>
            {
                var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value));
                foreach (var t in bytes)
                {
                    builder.Append(t.ToString("x2"));
                }  
            });  
            return builder.ToString();
        }
    }
}