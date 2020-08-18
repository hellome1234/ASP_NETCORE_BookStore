using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_BookStore.Data
{
    public class BookGallery
    {
        public int BookGalleryID { get; set; }
        public string PictureName { get; set; }
        public string URL { get; set; }
        public long BookID { get; set; }
        public Book Books { get; set; }
    }
}
