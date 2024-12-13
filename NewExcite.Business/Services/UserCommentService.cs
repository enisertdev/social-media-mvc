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
    public class UserCommentService : IUserCommentService
    {
        private readonly IUserCommentRepository _userCommentRepository;

        public UserCommentService(IUserCommentRepository userCommentRepository)
        {
            _userCommentRepository = userCommentRepository;
        }

        public void AddComment(UserPostComment comment)
        {
            _userCommentRepository.Add(comment);
        }

        public UserPostComment Get(Expression<Func<UserPostComment, bool>> filter)
        {
           return _userCommentRepository.Get(filter);
        }

        public IEnumerable<UserPostComment> GetComments(Expression<Func<UserPostComment, bool>> filter)
        {
           return _userCommentRepository.GetComments(filter);
        }
    }
}
