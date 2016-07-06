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
    public class PostCategoryService : BusinessService<post_category>, IPostCategoryService
    {
        public PostCategoryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<post_category, PostCategory>();
        }

        public PostCategoryService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<post_category, PostCategory>();
        }

        public PostCategory FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<post_category>();
            predicate = predicate.Or(p => p.RowID == ID);
            var data = _unitOfWork.Repository<post_category>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<post_category, PostCategory>(data);
        }

        public new IEnumerable<PostCategory> GetAll()
        {
            var data = _unitOfWork.Repository<post_category>().GetAll();
            return data.Select(p => Mapper.Map<post_category, PostCategory>(p));
        }

        public virtual bool Create(PostCategory Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<PostCategory, post_category>(Model);
                _unitOfWork.Repository<post_category>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(PostCategory Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<PostCategory, post_category>(Model);
                _unitOfWork.Repository<post_category>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(PostCategory Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<PostCategory, post_category>(Model);
                _unitOfWork.Repository<post_category>().Delete(entity);
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
