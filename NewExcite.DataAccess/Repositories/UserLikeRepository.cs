using Microsoft.EntityFrameworkCore;
using NewExcite.DataAccess.Abstract;
using NewExcite.DataAccess.Concrete.Data;
using NewExcite.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewExcite.DataAccess.Repositories
{
    public class UserLikeRepository : GenericRepository<UserPostLike>, IUserLikeRepository
    {
        private readonly NewExciteDbContext _newExciteDbContext;

        public UserLikeRepository(NewExciteDbContext newExciteDbContext)
        {
            _newExciteDbContext = newExciteDbContext;
        }
        public UserPostLike GetLike(Expression<Func<UserPostLike, bool>> filter)
        {
           return _newExciteDbContext.UserPostLikes.Include(x => x.User).Include(x => x.UserPost).Where(filter).FirstOrDefault();
        }
        public IEnumerable<UserPostLike> GetLikes(Expression<Func<UserPostLike, bool>> filter)
        {
            return _newExciteDbContext.UserPostLikes.Include(x => x.User).Include(x => x.UserPost).Where(filter).ToList();
        }
    }
}
