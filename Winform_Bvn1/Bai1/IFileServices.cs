using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    public interface IFileServices
    {
        void Save(string filepath, List<User> users);
        List<User> Load(string filepath);
    }
}
