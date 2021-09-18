using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public interface ICartItemService
    {
        public CartItem addCartItem(int userID, int shoeSizeID, int quantity);
        public CartItem updateQuantity(CartItem item);
        public bool deleteCartItem(int cartItemID);
        public CartItem GetCartItem(int userID, int shoeSizeID);
        public List<CartItem> getListCartItem(int userUD);
        public void deleteItemUser(int userID);
    }
}
