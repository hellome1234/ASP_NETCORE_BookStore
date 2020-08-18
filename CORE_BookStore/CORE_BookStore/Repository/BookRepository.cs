using CORE_BookStore.Data;
using CORE_BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext db;
        public BookRepository(BookStoreContext model)
        {
            db = model;
        }


        //...................................Book Manipulated methods....................................................//

            //save book
            public async Task<long> AddNewBook(BookModels model)
        {
            Book newbook = new Book()
            {
                BookName = model.BookName,
                AurtherName = model.AurtherName,
                Genre = model.Genre,
                Discription = model.Discription,
                LanguageID = model.LanguageID,
                TotalPage = model.TotalPage,
                BookCoverPhoto = model.BookCoverPhoto,
                BookURL = model.BookURL
            };
            //create a instance of BookGallery list to add all the BookGallery 
            newbook.bookGallery = new List<BookGallery>();
            //add all the picture, BookID and BookGalleryID is automatically added 
            foreach(var gallery in model.BookGallery)
            {
               newbook.bookGallery.Add(new BookGallery()
               {
                   //BookID and BookGalleryID is automatically provided 
                   URL = gallery.URL,
                   PictureName = gallery.PictureName
               });                
            }
            await db.Books.AddAsync(newbook);
            await db.SaveChangesAsync();
            return (int)newbook.BookID;
        }



        //...................................Book access Methods........................................................//
        //ReturnBook by Id
        public async Task<BookModels> GetByID(long ID)
        {
            return await db.Books.Where(x => x.BookID == ID).Select(newBook => new BookModels()
            {

                BookID = newBook.BookID,
                AurtherName = newBook.AurtherName,
                BookName = newBook.BookName,
                Discription = newBook.Discription,
                Genre = newBook.Genre,
                LanguageID = newBook.LanguageID,
                Language = newBook.Language.Name,
                TotalPage = newBook.TotalPage,
                BookCoverPhoto = newBook.BookCoverPhoto,
                BookURL = newBook.BookURL,
                BookGallery = newBook.bookGallery.Select(x=> new BookGalleryModels() { 
                    URL = x.URL,
                    PictureName = x.PictureName,
                    BookGalleryID = x.BookGalleryID
                }).ToList()
            }).FirstOrDefaultAsync();
            
            //if the book is empty it returns null          
        }
        //Return Book List
        public async Task<List<BookModels>> GetBookList() 
        {
           var books = await db.Books.ToListAsync();
            List<BookModels> BookList = new List<BookModels>();
             if(books?.Any() == true)
            {
                foreach (var book in books)
                {
                    BookList.Add( new BookModels(){ 
                        BookID = book.BookID, 
                        AurtherName = book.AurtherName, 
                        BookName = book.BookName, 
                        Discription = book.Discription, 
                        Genre = book.Genre, 
                        LanguageID = book.LanguageID,
                        TotalPage = book.TotalPage,
                        BookCoverPhoto = book.BookCoverPhoto    
                    });
                }
            }
            return BookList;            
            } 
       
        //Search Book
        public async Task<List<BookModels>> SearchBook(String BookName, String AurtherName)
        {
           var Books =await db.Books.Where(x => x.BookName.Contains(BookName) || x.AurtherName == AurtherName).ToListAsync();
            List<BookModels> BookList = new List<BookModels>();
            if (Books?.Any() == true)
            {
                foreach (var book in Books)
                {
                    BookList.Add(new BookModels()
                    {
                        BookID = book.BookID,
                        AurtherName = book.AurtherName,
                        BookName = book.BookName,
                        Discription = book.Discription,
                        Genre = book.Genre,
                        LanguageID = book.LanguageID,
                        TotalPage = book.TotalPage,
                        BookCoverPhoto = book.BookCoverPhoto

                    });
                }
            }
            return BookList;

        }
    
    }
}
