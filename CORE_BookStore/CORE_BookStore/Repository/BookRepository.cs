using CORE_BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_BookStore.Repository
{
    public class BookRepository
    {
        //ReturnBook by Id
        public BookModels GetByID(int ID)
        {
            return BookList.Where(x => x.BookID == ID).FirstOrDefault();
        }
        //Return Book List
        public List<BookModels> GetBookList() 
            {
                return BookList;
            } 
        //Search Book
        public List<BookModels> SearchBook(String BookName, String AurtherName)
        {
            return BookList.Where(x => x.BookName.Contains(BookName) || x.AurtherName == AurtherName).ToList();
        }
        //create a data source 
        private List<BookModels> BookList = new List<BookModels>()
        {
            new BookModels(){BookID=1,BookName="song of ice and fire",AurtherName="George R R martin",Discription="this is collection game of throne books",TotalPage=1234,Category="Fantasy",Language="English"},
             new BookModels(){BookID=2,BookName="Dune",AurtherName="Frank Herbert", Discription="This is space epic",TotalPage=1234,Category="Sify",Language="English"},
              new BookModels(){BookID=3,BookName="The GunSlinger",AurtherName="Stephen King", Discription="This is placed inside the stephen king horro",TotalPage=1234,Category="Horror",Language="English"},
              new BookModels(){BookID=3,BookName="Harry Porter",AurtherName="JK Rowling", Discription="This is a teenage fantasy novel sage",TotalPage=1234,Category="Fantasy",Language="English"},

        };
    }
}
