using Shoe.DAO;
using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public class ReviewServiceImp : IReviewService
    {
        private IReviewDAO reviewDAO;
        public ReviewServiceImp(IReviewDAO review)
        {
            reviewDAO = review;
        }
        public Review comment(int userID, int productID, string comment, int rating)
        {
            return reviewDAO.comment(userID, productID, comment, rating);
        }

        public List<Review> getComment(int productID)
        {
            return reviewDAO.getComment(productID);
        }
    }
}
