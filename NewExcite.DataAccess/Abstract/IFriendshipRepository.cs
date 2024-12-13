using NewExcite.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewExcite.DataAccess.Abstract
{
    public interface IFriendshipRepository : IGenericRepository<UserFriendship>
    {
        IEnumerable<UserFriendship> GetFriends(Expression<Func<UserFriendship, bool>> filter);
        UserFriendship GetFriend(Expression<Func<UserFriendship, bool>> filter);
    }
}
