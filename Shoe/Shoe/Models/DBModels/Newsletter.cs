
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

#nullable disable

namespace Shoe.Models.DBModels
{
    public partial class Newsletter
    {

        public int Id { get; set; }
        [Remote(action: "CheckSubcribe", controller: "Newsletter")]
        public string Email { get; set; }
        public int Subcribe { get; set; }
        public string Time { get; set; }

    }
}
