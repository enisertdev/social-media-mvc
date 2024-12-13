using NewExcite.Business.Services.Abstract;
using NewExcite.DataAccess.Abstract;
using NewExcite.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewExcite.Business.Services
{
    public class FriendshipService : IFriendshipService
    {
        private readonly IFriendshipRepository _friendshipRepository;

        public FriendshipService(IFriendshipRepository friendshipRepository)
        {
            _friendshipRepository = friendshipRepository;
        }

        public void Add(UserFriendship entity)
        {
            _friendshipRepository.Add(entity);
        }

        public void Delete(UserFriendship entity)
        {
            _friendshipRepository.Delete(entity);
        }

        public IEnumerable<UserFriendship> GetAll()
        {
           return _friendshipRepository.GetAll();
        }

        public UserFriendship GetById(int id)
        {
          return  _friendshipRepository.GetById(id);
        }

        public UserFriendship GetFriend(Expression<Func<UserFriendship, bool>> filter)
        {
            return _friendshipRepository.GetFriend(filter);
        }

        public IEnumerable<UserFriendship> GetFriends(Expression<Func<UserFriendship, bool>> filter)
        {
           return _friendshipRepository.GetFriends(filter);
        }

        public void Update(UserFriendship entity)
        {
            _friendshipRepository.Update(entity);
        }
    }
}
