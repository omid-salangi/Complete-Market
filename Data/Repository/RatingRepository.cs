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
    public class RatingRepository : IRatingRepository
    {
        private AppDbContext _context;

        public RatingRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddRatingToaProduct(string user, int productid, int rating)
        {
            Rating ratings = await _context.Ratings.Where(r => r.IdentityUserChangeId == user && r.ProductId==productid).FirstOrDefaultAsync();
            if (ratings == null)
            {
                Rating temp = new Rating()
                {
                    IdentityUserChangeId = user,
                    ProductId = productid,
                    RatingNumber = rating
                };
                await _context.Ratings.AddAsync(temp);
                _context.SaveChanges();
            }
            else
            {
                ratings.RatingNumber = rating;
                _context.SaveChanges();
            }
            return;

        }

    }
}
