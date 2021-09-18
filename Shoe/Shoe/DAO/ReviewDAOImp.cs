using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.DAO
{
    public class ReviewDAOImp : IReviewDAO
    {
        private shoeContext _context;
        public ReviewDAOImp(shoeContext context)
        {
            _context = context;
        }
        public Review comment(int userID, int productID, string comment, int rating)
        {
            Review review = new Review();
            review.UserId = userID;
            review.ProductId = productID;
            review.Comment = comment;
            review.Rating = rating;
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return review;
        }

        public List<Review> getComment(int productID)
        {
            List<Review> reviewList = _context.Reviews.Where(o => o.ProductId == productID).ToList();
            return reviewList;
        }
    }
}
