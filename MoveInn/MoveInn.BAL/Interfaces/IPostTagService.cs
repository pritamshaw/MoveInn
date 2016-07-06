using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface IPostTagService : IBusinessService<post_tag>
    {
        PostTag FindByID(int ID);
        new IEnumerable<PostTag> GetAll();
        bool Create(PostTag entity);
        bool Delete(PostTag entity);
        bool Update(PostTag entity);
    }
}
