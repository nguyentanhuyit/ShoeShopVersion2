using System;
using System.Collections.Generic;

#nullable disable

namespace Shoe.Models.DBModels
{
    public partial class Review
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public string Comment { get; set; }
        public int? Rating { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
