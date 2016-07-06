using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface IPostCategoryService : IBusinessService<post_category>
    {
        PostCategory FindByID(int ID);
        new IEnumerable<PostCategory> GetAll();
        bool Create(PostCategory entity);
        bool Delete(PostCategory entity);
        bool Update(PostCategory entity);
    }
}
