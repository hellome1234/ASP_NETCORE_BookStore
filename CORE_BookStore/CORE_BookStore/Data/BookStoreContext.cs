using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_BookStore.Data
{
    public class BookStoreContext:DbContext
    {
        //pass ContextType to DbContextOptions and also pass it to base constructor , in this case it's BookStoreContext
        public BookStoreContext(DbContextOptions<BookStoreContext> options ):
            base(options)
        {

        }
    
        public DbSet<Book> Books { get; set; }
        public DbSet<BookGallery> BookGallery { get; set; }
        public DbSet<Language> Languages { get; set; }


    }
}
