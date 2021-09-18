using Shoe.Models.DBModels;
using Shoe.Service;
using System.Linq;

namespace Shoe.DAO
{
    public class NewsletterDAOImp : INewsletterDAO
    {
        private shoeContext _context;
        public NewsletterDAOImp(shoeContext ShoeContext)
        {
            _context = ShoeContext;
        }

        public bool CheckSubcribe(string email)
        {
            Newsletter user =  _context.Newsletters.Where(o => o.Email.Equals(email)).FirstOrDefault();
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public void subcribe(Newsletter newsletter)
        {
            _context.Newsletters.Add(newsletter);
            _context.SaveChanges();
        }
    }
}
