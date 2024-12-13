using NewExcite.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewExcite.DataAccess.Abstract
{
    public interface IUserLikeRepository : IGenericRepository<UserPostLike>
    {
        UserPostLike GetLike(Expression<Func<UserPostLike, bool>> filter);
        IEnumerable<UserPostLike> GetLikes(Expression<Func<UserPostLike, bool>> filter);
    }
}
