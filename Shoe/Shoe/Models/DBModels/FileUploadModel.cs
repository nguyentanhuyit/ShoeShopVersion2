using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shoe.Models.DBModels
{
    public class FileUploadModel
    {
        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public int id { get; set; }
        public string file1 { get; set; }
        public string file2 { get; set; }
        public string file3 { get; set; }
        public string main_img { get; set; }

    }
}