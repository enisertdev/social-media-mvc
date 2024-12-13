using NewExcite.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewExcite.Business.Services.Abstract
{
    public interface IUserPostService
    {
        void Add(UserPost userPost);
        void Update(UserPost userPost);
        void Delete(UserPost userPost);
        UserPost GetById(int id);
        IEnumerable<UserPost> GetAll();
        UserPost GetPost(Expression<Func<UserPost, bool>> filter);
        IEnumerable<UserPost> GetPosts(Expression<Func<UserPost, bool>> filter);
        IEnumerable<UserPost> GetAllPosts();

    }
}
