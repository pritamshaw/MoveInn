using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.DAL.EntityModel;
using MoveInn.DAL.Interfaces;
using MoveInn.DAL.Repository;

namespace MoveInn.DAL.UOW
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        public UnitOfWork()
        {
            _dbContext = new MoveInnEntities();
        }

        public UnitOfWork(MoveInnEntities context)
        {
            _dbContext = context;
        }
        private MoveInnEntities _dbContext;
        private Hashtable _repositories;
        //private GenericRepository<category> _Categories;
        //private GenericRepository<@event> _Events;
        //private GenericRepository<event_category> _EventCategories;
        //private GenericRepository<event_participation> _EventParticipations;
        //private GenericRepository<event_setting> _EventSettings;
        //private GenericRepository<participation_category> _ParticipationCategories;
        //private GenericRepository<post> _Posts;
        //private GenericRepository<post_category> _PostCategories;
        //private GenericRepository<post_comment> _PostComments;
        //private GenericRepository<post_notify> _PostNotifications;
        //private GenericRepository<post_tag> _PostTags;
        //private GenericRepository<profile> _Profiles;
        //private GenericRepository<profile_category> _ProfileCategories;
        //private GenericRepository<profile_member> _ProfileMembers;
        //private GenericRepository<profile_setting> _ProfileSettings;
        //private GenericRepository<profile_talent> _ProfileTalents;
        //private GenericRepository<right> _Rights;
        //private GenericRepository<right_role> _RightRoles;
        //private GenericRepository<role> _Roles;
        //private GenericRepository<setting> _Settings;
        //private GenericRepository<setting_category> _SettingCategories;
        //private GenericRepository<setting_datatype> _SettingDataTypes;
        //private GenericRepository<talent> _Talents;
        //private GenericRepository<user> _Users;
        //private GenericRepository<user_role> _UserRoles;
        //private GenericRepository<user_setting> _UserSettings;

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        private bool disposed = false;

        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
            this.disposed = true;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                            .MakeGenericType(typeof(T)), _dbContext);

                _repositories.Add(type, repositoryInstance);
            }

            return (IRepository<T>)_repositories[type];
        }
    }

}
