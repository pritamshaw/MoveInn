using MoveInn.BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveInn.BAL.Services
{
    public class SecurityDataServices : IDataService
    {
        public IUserService Service;
        public SecurityDataServices()
        {
            Service = new UserService();
        }
        public bool CheckCredentials(string email, string password)
        {
            try
            {
                var result = Service.FindByCredentials(email,password);
                if (result == null)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
