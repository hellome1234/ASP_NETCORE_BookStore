using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_BookStore.Data
{
    public class Book
    {
        public long BookID { get; set; }
        public string BookName { get; set; }
        public string AurtherName { get; set; }
        public string Discription { get; set; }
        public string Genre { get; set; }
        public int TotalPage { get; set; }
        public int LanguageID { get; set; }
        public Language Language { get; set; }
        public string BookCoverPhoto { get; set; }

        public ICollection<BookGallery> bookGallery { get; set; }

        public string BookURL { get; set; }

    }
}
