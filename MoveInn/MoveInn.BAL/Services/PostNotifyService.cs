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
    public class PostNotifyService : BusinessService<post_notify>, IPostNotifyService
    {
        public PostNotifyService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<post_notify, PostNotify>();
        }

        public PostNotifyService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<post_notify, PostNotify>();
        }

        public PostNotify FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<post_notify>();
            predicate = predicate.Or(p => p.ID == ID);
            var data = _unitOfWork.Repository<post_notify>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<post_notify, PostNotify>(data);
        }

        public new IEnumerable<PostNotify> GetAll()
        {
            var data = _unitOfWork.Repository<post_notify>().GetAll();
            return data.Select(p => Mapper.Map<post_notify, PostNotify>(p));
        }

        public virtual bool Create(PostNotify Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<PostNotify, post_notify>(Model);
                _unitOfWork.Repository<post_notify>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(PostNotify Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<PostNotify, post_notify>(Model);
                _unitOfWork.Repository<post_notify>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(PostNotify Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<PostNotify, post_notify>(Model);
                _unitOfWork.Repository<post_notify>().Delete(entity);
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
