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
    public class UserCommentRepository : GenericRepository<UserPostComment>, IUserCommentRepository
    {
        private readonly NewExciteDbContext _dbContext;

        public UserCommentRepository(NewExciteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserPostComment Get(Expression<Func<UserPostComment, bool>> filter)
        {
            return _dbContext.UserPostComments.Include(x => x.UserPost).Include(x => x.User).FirstOrDefault(filter);
        }

        public IEnumerable<UserPostComment> GetComments(Expression<Func<UserPostComment, bool>> filter)
        {
            return _dbContext.UserPostComments.Include(x => x.UserPost).Include(x => x.User).Where(filter).ToList();
        }

    }
}
