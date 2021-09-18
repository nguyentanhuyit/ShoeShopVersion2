using Shoe.Models.DBModels;
using System.Linq;

namespace Shoe.DAO
{
    public class ContactDAOImp : IContactDAO
    {
        private shoeContext _context;
        public ContactDAOImp(shoeContext ShoeContext)
        {
            _context = ShoeContext;
        }

        public void addMessage(Contact userMessage)
        {
            _context.Contacts.Add(userMessage);
            _context.SaveChanges();
        }
    }
}
