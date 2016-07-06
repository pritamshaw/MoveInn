using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.DAL.EntityModel;
using MoveInn.DAL.Interfaces;
using MoveInn.BAL.Interfaces;
using MoveInn.BAL.Models;
using AutoMapper;
using LinqKit;
using MoveInn.DAL.UOW;

namespace MoveInn.BAL.Services
{
    public class PostCommentService : BusinessService<post_comment>, IPostCommentService
    {
        public PostCommentService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<post_comment, PostComment>();
        }

        public PostCommentService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<post_comment, PostComment>();
        }

        public PostComment FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<post_comment>();
            predicate = predicate.Or(p => p.RowID == ID);
            var data = _unitOfWork.Repository<post_comment>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<post_comment, PostComment>(data);
        }

        public new IEnumerable<PostComment> GetAll()
        {
            var data = _unitOfWork.Repository<post_comment>().GetAll();
            return data.Select(p => Mapper.Map<post_comment, PostComment>(p));
        }

        public virtual bool Create(PostComment Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<PostComment, post_comment>(Model);
                _unitOfWork.Repository<post_comment>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(PostComment Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<PostComment, post_comment>(Model);
                _unitOfWork.Repository<post_comment>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(PostComment Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<PostComment, post_comment>(Model);
                _unitOfWork.Repository<post_comment>().Delete(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

    }
}
