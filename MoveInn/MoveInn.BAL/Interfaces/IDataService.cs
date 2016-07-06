using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveInn.BAL.Interfaces
{
    public interface IDataService
    {
        bool CheckCredentials(string username, string password);
    }
}
