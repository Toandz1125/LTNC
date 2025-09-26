using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    public class FileServices
    {
        public void Save(string filepath, List<User> users)
        {
            using (var writer = new System.IO.StreamWriter(filepath))
            {
                foreach (var user in users)
                {
                    writer.WriteLine($"{user.Username},{user.Password}");
                }
            }
        }
        public List<User> Load(string filepath)
        {
            var users = new List<User>();
            if (!System.IO.File.Exists(filepath))
            {
                return users;
            }
            using (var reader = new System.IO.StreamReader(filepath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        users.Add(new User { Username = parts[0], Password = parts[1] });
                    }
                }
            }
            return users;
        }
    }
}
