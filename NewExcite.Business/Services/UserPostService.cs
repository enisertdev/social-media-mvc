using NewExcite.Business.Services.Abstract;
using NewExcite.DataAccess.Abstract;
using NewExcite.Entitiy.Concrete;
using System.Linq.Expressions;

namespace NewExcite.Business.Services
{
    public class UserPostService : IUserPostService
    {
        private readonly IUserPostRepository _userPostRepository;

        public UserPostService(IUserPostRepository userPostRepository)
        {
            _userPostRepository = userPostRepository;
        }

        public void Add(UserPost userPost)
        {
            _userPostRepository.Add(userPost);
        }

        public void Delete(UserPost userPost)
        {
            _userPostRepository.Delete(userPost);
        }

        public IEnumerable<UserPost> GetAll()
        {
            return _userPostRepository.GetAll();
        }

        public IEnumerable<UserPost> GetAllPosts()
        {
            return _userPostRepository.GetAllPosts();
        }

        public UserPost GetById(int id)
        {
            return _userPostRepository.GetById(id);
        }

        public UserPost GetPost(Expression<Func<UserPost, bool>> filter)
        {
            return _userPostRepository.GetPost(filter);
        }

        public IEnumerable<UserPost> GetPosts(Expression<Func<UserPost, bool>> filter)
        {
            return _userPostRepository.GetPosts(filter);
                }

        public void Update(UserPost userPost)
        {
            _userPostRepository.Update(userPost);
        }
    }
}
