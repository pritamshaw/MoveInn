using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface IProfileMemberService : IBusinessService<profile_member>
    {
        ProfileMember FindByID(int ID);
        new IEnumerable<ProfileMember> GetAll();
        bool Create(ProfileMember entity);
        bool Delete(ProfileMember entity);
        bool Update(ProfileMember entity);
    }
}
