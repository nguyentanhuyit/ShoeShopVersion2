using Shoe.Models.DBModels;

namespace Shoe.Controllers
{
    public interface INewsletterService
    {
        public void subcribe(Newsletter newsletter);
        public bool CheckSubcribe(string email);
    }
}