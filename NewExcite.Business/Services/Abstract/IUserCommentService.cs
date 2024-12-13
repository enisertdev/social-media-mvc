using NewExcite.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewExcite.Business.Services.Abstract
{
    public interface IUserCommentService
    {
        UserPostComment Get(Expression<Func<UserPostComment, bool>> filter);
        IEnumerable<UserPostComment> GetComments(Expression<Func<UserPostComment, bool>> filter);
        void AddComment(UserPostComment comment);
    }
}
