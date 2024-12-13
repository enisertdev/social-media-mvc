using NewExcite.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewExcite.DataAccess.Abstract
{
    public interface IUserCommentRepository : IGenericRepository<UserPostComment>
    {
        UserPostComment Get(Expression<Func<UserPostComment, bool>> filter);
        IEnumerable<UserPostComment> GetComments(Expression<Func<UserPostComment, bool>> filter);
    }
}
