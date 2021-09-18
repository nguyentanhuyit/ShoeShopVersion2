using System;
using System.Collections.Generic;

#nullable disable

namespace Shoe.Models.DBModels
{
    public partial class CartItem
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ShoeSizeId { get; set; }
        public int? Quantity { get; set; }

        public virtual ShoeSizeDetail ShoeSize { get; set; }
        public virtual User User { get; set; }
    }
}
