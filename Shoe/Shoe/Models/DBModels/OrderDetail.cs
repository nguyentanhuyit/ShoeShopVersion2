using System;
using System.Collections.Generic;

#nullable disable

namespace Shoe.Models.DBModels
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ShoeSizeId { get; set; }
        public int? Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual ShoeSizeDetail ShoeSize { get; set; }
    }
}
