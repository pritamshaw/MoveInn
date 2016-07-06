using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface IPostNotifyService : IBusinessService<post_notify>
    {
        PostNotify FindByID(int ID);
        new IEnumerable<PostNotify> GetAll();
        bool Create(PostNotify entity);
        bool Delete(PostNotify entity);
        bool Update(PostNotify entity);
    }
}
