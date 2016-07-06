using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveInn.BAL.Interfaces
{
    public interface ICustomAuthentication
    {
        bool Authenticate(string username, string password, bool ispersistent);

        void CreateCustomPrincipal();
    }
}
