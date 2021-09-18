using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.DAO
{
    public interface IReviewDAO
    {
        public List<Review> getComment(int productID);
        public Review comment(int userID, int productID, string comment, int rating);
    }
}
