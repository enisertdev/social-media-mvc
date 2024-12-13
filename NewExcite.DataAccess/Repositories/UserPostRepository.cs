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
    public class UserPostRepository : GenericRepository<UserPost>, IUserPostRepository
    {
        private readonly NewExciteDbContext _dbContext;

        public UserPostRepository(NewExciteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<UserPost> GetAllPosts()
        {
            return _dbContext.UserPosts.Include(u => u.User).Include(u => u.PostComments).Include(u => u.PostLikes).ThenInclude(u => u.User).ToList();
        }

        public UserPost GetPost(Expression<Func<UserPost, bool>> filter)
        {
            return _dbContext.UserPosts.Include(u => u.User).Include(u => u.PostComments).Include(x => x.PostLikes).ThenInclude(u=> u.User).Where(filter).FirstOrDefault();
        }
        public IEnumerable<UserPost> GetPosts(Expression<Func<UserPost, bool>> filter)
        {
            return _dbContext.UserPosts.Include(u => u.User).Include(u => u.PostComments).Include(x => x.PostLikes).ThenInclude(u => u.User).Where(filter).ToList();
        }
    }
}
