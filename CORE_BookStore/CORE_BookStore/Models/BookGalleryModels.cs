using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_BookStore.Models
{
    public class BookGalleryModels
    {
        public int BookGalleryID { get; set; }
        public string PictureName { get; set; }
        public string URL { get; set; }
        public int BookID { get; set; }
        public BookModels Book { get; set; } 

    }
}
