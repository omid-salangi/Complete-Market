using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Domain.Interface;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class CommentRepository:ICommentRepository
    {
        private AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task ShowComment(int commentid)
        {
            Comments temp = await _context.Comments.FindAsync(commentid);
            temp.IsShow = true;
            _context.Comments.Update(temp);
             _context.SaveChanges();
        }

        public async Task DeleteComment(int id)
        {
            Comments temp = await _context.Comments.FindAsync(id);
            _context.Comments.Remove(temp);
             _context.SaveChanges();
        }

        public async Task AddComment(string userid,int productid,string comment)
        {
            Comments temp = new Comments()
            {
                Comment = comment,
                IsShow = false,
                DateTime = DateTime.Now
            };
            _context.Comments.Add(temp);
            _context.SaveChanges();
            temp.IdentityUserChangeId = userid;
            temp.ProductId = productid;
             _context.SaveChanges();
        }

        public async Task EditComment(int commentid, string comment)
        {
            Comments temp = await _context.Comments.FindAsync(commentid);
                temp.Comment = comment;
                 _context.SaveChanges();

        }
    }
}
