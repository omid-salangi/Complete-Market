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
     //public class RatingRepository:IRatingRepository
     //{
     //    private AppDbContext _context;

     //    public RatingRepository(AppDbContext context)
     //    {
     //        _context = context;
     //    }
//        public async Task AddRatingToaProduct(string user, int productid, int rating)
//        {
//            IdentityUserChange temp = await _context.Users.FindAsync(user);
//            if (temp.RatingId==-1)
//            {
//                Rating ratingtemp = new Rating() { };
//               await _context.Ratings.AddAsync(ratingtemp);
//               _context.SaveChanges();
//               temp.RatingId = ratingtemp.Id;
//               _context.SaveChanges();
//               RatingDetail rdtemp = new RatingDetail()
//               {
//                   ProductId = productid,
//                   RatingId = rating

//               };
//               _context.SaveChanges();
//               rdtemp.Id = ratingtemp.Id;
//               _context.SaveChanges();
//            }
//            return;
            
//        }

//        public async Task ChangeRatingOfaProduct(string user, int productid, int rating)
//        {
//            IdentityUserChange tempuser = await _context.Users.FindAsync(user);
//            if (tempuser.RatingId == -1)
//            {
//                AddRatingToaProduct(user, productid, rating);
//                return;
//            }
//            else
//            {
//                int rat = tempuser.RatingId;
//                RatingDetail temp =await _context.RatingDetails.Where(n => n.RatingId == rat && n.ProductId==productid).FirstOrDefaultAsync();
//                temp.RatingNumber = rating;
//                _context.SaveChanges();

//            }
          

//        }
//    }
}
