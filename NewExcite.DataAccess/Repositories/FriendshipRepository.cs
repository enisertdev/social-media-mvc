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
    public class FriendshipRepository : GenericRepository<UserFriendship>, IFriendshipRepository
    {
        private readonly NewExciteDbContext _dbContext;

        public FriendshipRepository(NewExciteDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<UserFriendship> GetFriends(Expression<Func<UserFriendship, bool>> filter)
        {
           return _dbContext.UserFriendships.Include(u => u.UserFollower).Include(u => u.UserFollowed).Where(filter).ToList();
        }
        public UserFriendship GetFriend(Expression<Func<UserFriendship, bool>> filter)
        {
            return _dbContext.UserFriendships.Include(u => u.UserFollower).Include(u => u.UserFollowed).Where(filter).FirstOrDefault();
        }
    }
}
