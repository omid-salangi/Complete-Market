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
        public async Task<IEnumerable<Comments>> GetCommentsByProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task IsShowComment(int commentid)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteComment(int id)
        {
            throw new NotImplementedException();
        }

        public async Task AddComment(string userid, int productid, string comment)
        {
            throw new NotImplementedException();
        }

        public async Task EditComment(int commentid, string comment)
        {
            throw new NotImplementedException();
        }
    }
}
