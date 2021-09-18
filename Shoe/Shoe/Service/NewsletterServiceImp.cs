using Shoe.Controllers;
using Shoe.DAO;
using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public class NewsletterServiceImp : INewsletterService
    {
        private INewsletterDAO newsletterDAO;
        public NewsletterServiceImp(INewsletterDAO newsletter)
        {
            newsletterDAO = newsletter;
        }

        public bool CheckSubcribe(string email)
        {
            return newsletterDAO.CheckSubcribe(email);
        }

        public void subcribe(Newsletter newsletter)
        {
            newsletterDAO.subcribe(newsletter);
        }
    }
}
