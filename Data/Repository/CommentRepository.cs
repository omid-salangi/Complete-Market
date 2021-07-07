using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;
using Domain.Models;

namespace Data.Repository
{
    public class CommentRepository:ICommentRepository
    {
        public Task<IEnumerable<Comments>> GetCommentsByProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task IsShowComment(int commentid)
        {
            throw new NotImplementedException();
        }

        public Task DeleteComment(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddComment(string userid, int productid, string comment)
        {
            throw new NotImplementedException();
        }

        public Task EditComment(int commentid, string comment)
        {
            throw new NotImplementedException();
        }
    }
}
