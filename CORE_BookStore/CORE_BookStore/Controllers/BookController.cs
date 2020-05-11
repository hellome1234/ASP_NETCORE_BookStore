using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CORE_BookStore.Models;
using CORE_BookStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CORE_BookStore.Controllers
{
    public class BookController : Controller
    {
        //create a instance of Book repository in constuctor
        private readonly BookRepository bookRepository = null;
        public BookController()
        {
            bookRepository = new BookRepository();
        }
        public IActionResult Index()
        {
            return View();
        }
        //get book by id
        public ViewResult GetBook(int id )
        {
            return View(bookRepository.GetByID(id));
        }
        //get book list
        public ViewResult GetAllBook()
        {
            return View(bookRepository.GetBookList());
        }
        //search book
        public List<BookModels> SearchBooks(String bookName, String aurtherName)
        {
            return bookRepository.SearchBook(bookName, aurtherName);
        }
    }
}