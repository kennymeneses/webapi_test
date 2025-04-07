using System.Security.Cryptography;
using System.Text;

namespace api.application.Configurations;

public static class ExtensionMethods
{
    public static string ToHash(this string value)
    {
        using(var sha256 = SHA256.Create())
        {
            var BytesText = Encoding.UTF8.GetBytes(value);
            var HashBytes = sha256.ComputeHash(BytesText);
            string HashString = BitConverter.ToString(HashBytes).Replace("-", "");

            return HashString;
        }
    }
}