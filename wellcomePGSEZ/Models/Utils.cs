using System.Security.Cryptography;
using System.Text;

namespace wellcomePGSEZ.Models
{
    public class Utils
    {
        public Utils()
        {


        }

        public String hassPass()
        {
            // رمز شما
            string password = "@lirezA1281";

            // هش کردن با SHA-256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // تبدیل رشته به آرایه‌ای از بایت‌ها
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // تبدیل آرایه بایت‌ها به رشته هگزا دسیمال
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                string hashedPassword = builder.ToString();
                Console.WriteLine($"The hashed password is: {hashedPassword}");
                return hashedPassword;
            }
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
