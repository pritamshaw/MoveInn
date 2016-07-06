using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface IPostService : IBusinessService<post>
    {
        Post FindByID(int ID);
        new IEnumerable<Post> GetAll();
        bool Create(Post entity);
        bool Delete(Post entity);
        bool Update(Post entity);
    }
}
