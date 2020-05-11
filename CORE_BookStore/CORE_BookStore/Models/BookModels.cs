using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_BookStore.Models
{
    public class BookModels
    {
        public long BookID { get; set; }

        public String BookName { get; set; }
        public String AurtherName { get; set; }
        public String Discription { get; set; }
        public String Category { get; set; }
        public int TotalPage { get; set; }
        public String Language { get; set; }


    }
}
