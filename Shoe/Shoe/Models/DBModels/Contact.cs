
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Shoe.Models.DBModels
{
    public partial class Contact
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }

        public string Time { get; set; }

    }
}
