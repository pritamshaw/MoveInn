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
    public class PostService : BusinessService<post>, IPostService
    {
        public PostService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<post, Post>();
        }

        public PostService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<post, Post>();
        }

        public Post FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<post>();
            predicate = predicate.Or(p => p.RowID == ID);
            var data = _unitOfWork.Repository<post>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<post, Post>(data);
        }

        public new IEnumerable<Post> GetAll()
        {
            var data = _unitOfWork.Repository<post>().GetAll();
            return data.Select(p => Mapper.Map<post, Post>(p));
        }

        public virtual bool Create(Post Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<Post, post>(Model);
                _unitOfWork.Repository<post>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(Post Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<Post, post>(Model);
                _unitOfWork.Repository<post>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(Post Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<Post, post>(Model);
                _unitOfWork.Repository<post>().Delete(entity);
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
