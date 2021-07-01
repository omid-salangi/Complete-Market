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
       IEnumerable<Comments> getCommentsByProduct(int id);
       void IsShowComment(int commentid);
       void DeleteComment(int id);
       void AddComment(string userid, int productid, string comment);
       void EditComment(int commentid, string comment);

   }
}
