using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.DAL.EntityModel;
using MoveInn.DAL.Repository;

namespace MoveInn.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //GenericRepository<category> _Categories;
        //GenericRepository<@event> _Events;
        //GenericRepository<event_category> _EventCategories;
        //GenericRepository<event_participation> _EventParticipations;
        //GenericRepository<event_setting> _EventSettings;
        //GenericRepository<participation_category> _ParticipationCategories;
        //GenericRepository<post> _Posts;
        //GenericRepository<post_category> _PostCategories;
        //GenericRepository<post_comment> _PostComments;
        //GenericRepository<post_notify> _PostNotifications;
        //GenericRepository<post_tag> _PostTags;
        //GenericRepository<profile> _Profiles;
        //GenericRepository<profile_category> _ProfileCategories;
        //GenericRepository<profile_member> _ProfileMembers;
        //GenericRepository<profile_setting> _ProfileSettings;
        //GenericRepository<profile_talent> _ProfileTalents;
        //GenericRepository<right> _Rights;
        //GenericRepository<right_role> _RightRoles;
        //GenericRepository<role> _Roles;
        //GenericRepository<setting> _Settings;
        //GenericRepository<setting_category> _SettingCategories;
        //GenericRepository<setting_datatype> _SettingDataTypes;
        //GenericRepository<talent> _Talents;
        //GenericRepository<user> _Users;
        //GenericRepository<user_role> _UserRoles;
        //GenericRepository<user_setting> _UserSettings;

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Commit();
        IRepository<T> Repository<T>() where T : class;
    }
}
