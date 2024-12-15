using System.Security.Claims;

namespace SkillFoundryAuthBasics.Models
{
    public class UserManager
    {
        private static List<UserAccount> _accounts;

        static UserManager()
        {
            _accounts = [
                new UserAccount
                {
                    UserName = "admin",
                    Password = "testing123",
                    Claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, "admin"),
                        new Claim("admin", "true")
                    }
                },
                new UserAccount
                {
                    UserName = "jdoe",
                    Password = "testing123",
                    Claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, "jdoe")
                    }
                },
                ];
        }

        public static UserAccount Login(string username, string password)
        {
            return _accounts.FirstOrDefault(a =>
                a.UserName == username && a.Password == password);
        }
    }

    public class UserAccount
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Claim> Claims { get; set; }
    }
}
