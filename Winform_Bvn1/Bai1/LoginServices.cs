using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    public class LoginServices : IloginServices
    {
        public bool Login(string username, string password)
        {
            var loginResult = false;
            var users = GetUsers();
            if (username == null || password == null)
            {
                return false;
            }
            foreach (var user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        private static List<User> GetUsers()
        {
            var fileService = new FileServices();
            //string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "User.txt");
            var users = fileService.Load("D:\\C#\\LTNC\\Winform_1\\Bai1\\User.txt");
            return users;
        }
    }
}
