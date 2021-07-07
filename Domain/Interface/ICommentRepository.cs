using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interface
{
   public  interface ICommentRepository
   {
       Task<IEnumerable<Comments>> GetCommentsByProduct(int id);
       Task IsShowComment(int commentid);
       Task DeleteComment(int id);
       Task AddComment(string userid, int productid, string comment);
       Task EditComment(int commentid, string comment);

   }
}
