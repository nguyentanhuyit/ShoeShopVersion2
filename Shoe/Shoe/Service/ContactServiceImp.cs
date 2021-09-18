using Shoe.DAO;
using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public class ContactServiceImp : IContactService
    {
        private IContactDAO contactDAO;
        public ContactServiceImp(IContactDAO contact)
        {
            contactDAO = contact;
        }

        public void addMessage(Contact userMessage)
        {
           contactDAO.addMessage(userMessage);
        }
    }
}
