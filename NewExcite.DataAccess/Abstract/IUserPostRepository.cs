using NewExcite.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewExcite.DataAccess.Abstract
{
    public interface IUserPostRepository : IGenericRepository<UserPost>
    {
        UserPost GetPost(Expression<Func<UserPost, bool>> filter);
        IEnumerable<UserPost> GetPosts(Expression<Func<UserPost, bool>> filter);
        IEnumerable<UserPost> GetAllPosts();

    }
}
