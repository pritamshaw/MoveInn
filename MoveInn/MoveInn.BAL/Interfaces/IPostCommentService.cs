using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface IPostCommentService : IBusinessService<post_comment>
    {
        PostComment FindByID(int ID);
        new IEnumerable<PostComment> GetAll();
        bool Create(PostComment entity);
        bool Delete(PostComment entity);
        bool Update(PostComment entity);
    }
}
