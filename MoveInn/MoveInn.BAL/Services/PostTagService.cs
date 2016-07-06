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
    public class PostTagService : BusinessService<post_tag>, IPostTagService
    {
        public PostTagService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<post_tag, PostTag>();
        }

        public PostTagService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<post_tag, PostTag>();
        }

        public PostTag FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<post_tag>();
            predicate = predicate.Or(p => p.ID == ID);
            var data = _unitOfWork.Repository<post_tag>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<post_tag, PostTag>(data);
        }

        public new IEnumerable<PostTag> GetAll()
        {
            var data = _unitOfWork.Repository<post_tag>().GetAll();
            return data.Select(p => Mapper.Map<post_tag, PostTag>(p));
        }

        public virtual bool Create(PostTag Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<PostTag, post_tag>(Model);
                _unitOfWork.Repository<post_tag>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(PostTag Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<PostTag, post_tag>(Model);
                _unitOfWork.Repository<post_tag>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(PostTag Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<PostTag, post_tag>(Model);
                _unitOfWork.Repository<post_tag>().Delete(entity);
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
