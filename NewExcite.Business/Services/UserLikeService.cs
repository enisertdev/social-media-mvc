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
    public class UserLikeService : IUserLikeService
    {
        private readonly IUserLikeRepository _userLikeRepository;

        public UserLikeService(IUserLikeRepository userLikeRepository)
        {
            _userLikeRepository = userLikeRepository;
        }

        public void Add(UserPostLike entity)
        {
            _userLikeRepository.Add(entity);
        }

        public void Delete(UserPostLike entity)
        {
            _userLikeRepository.Delete(entity);
        }

        public IEnumerable<UserPostLike> GetAll()
        {
            return _userLikeRepository.GetAll();
        }

        public UserPostLike GetById(int id)
        {
            return _userLikeRepository.GetById(id);
        }

        public UserPostLike GetLike(Expression<Func<UserPostLike, bool>> filter)
        {
            return _userLikeRepository.GetLike(filter);
        }

        public IEnumerable<UserPostLike> GetLikes(Expression<Func<UserPostLike, bool>> filter)
        {
            return _userLikeRepository.GetLikes(filter);
        }

        public void Update(UserPostLike entity)
        {
            _userLikeRepository.Update(entity);
        }
    }
}
