using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    public interface IloginServices
    {
        bool Login(string username, string password);
    }
}
