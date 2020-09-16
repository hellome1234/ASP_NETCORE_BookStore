using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CORE_BookStore.Models;
using CORE_BookStore.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CORE_BookStore.Controllers
{

    public class BookController : Controller
    {
        //attributes
        [ViewData]
        public String Title { get; set; }
        [ViewData]
        public BookModels Book { get; set; }

        //create a instance of Book repository in constuctor
        private readonly BookRepository bookRepository = null;
        public readonly LanguageRepository languageRepository = null;
        public readonly IWebHostEnvironment webHostEnvironment;
        public BookController(BookRepository _bookRepository,LanguageRepository _languageRepository, IWebHostEnvironment _webHostEnvironment)
        {
            bookRepository = _bookRepository;
            languageRepository = _languageRepository;
            webHostEnvironment = _webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        //..............................................Book Access View.......................................//
       
        //get book by id
        [Route("Book-Details/{id}",Name ="GetBook")]
        public async Task<ViewResult> GetBook(long id )
        {            
            Title = "Book Details";
            BookModels book =await bookRepository.GetByID(id);
            Book = book;
            return View(book);
        }
      
        //get book list
        public async Task<ViewResult> GetAllBook()
        {
            Title = "All Books";
            return View(await bookRepository.GetBookList());
        }
       
        //search book
        public async Task<List<BookModels>> SearchBooks(String bookName, String aurtherName)
        {
           List<BookModels> BooksList = await bookRepository.SearchBook(bookName, aurtherName);
            return BooksList;
        }
        //..........................................................................................................//


        //........................................Book Save Form....................................................//
        //Get Method
        public async  Task<ViewResult> UploadBook(bool isSuccess = false, int BookID = 0)
        {
            Title = "Upload Book";
            ViewBag.Languages = await LanguageDropDown();
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookID = BookID;
            return View();
        }
       
        //POST method
        [HttpPost]
        public async Task<IActionResult> UploadBook(BookModels book)
        {
            if (ModelState.IsValid)
            {
                //check if FormFile is not null
                if(book.CoverPhotoFile != null)
                {
                    //function call to save image to mention file                   
                   //pass book path with filename to book model 
                    book.BookCoverPhoto = await SaveImage("Images/Books/CoverPhoto/", book.CoverPhotoFile); ;

                }
                if(book.BookGalleries != null)
                {
                    book.BookGallery = new List<BookGalleryModels>();
                    foreach(IFormFile file in book.BookGalleries)
                    {
                        BookGalleryModels Gallery = new BookGalleryModels() { 
                        PictureName = file.FileName,
                        URL = await SaveImage("Images/Books/GalleryPhoto", file)
                        };
                        book.BookGallery.Add(Gallery);                      
                    }
                }
                if(book.BookPDF != null)
                {   
                    string BookFile = "BookPDF/" + Guid.NewGuid().ToString() + "_" + book.BookPDF.FileName;
                    //create a url to save the book in the server
                    string serverFolder = Path.Combine(webHostEnvironment.WebRootPath, BookFile);
                    await book.BookPDF.CopyToAsync(new FileStream(serverFolder,FileMode.Create));
                    book.BookURL = "/" + BookFile;
                }
                long id = await bookRepository.AddNewBook(book);
                if (id > 0)
                {
                    return RedirectToAction(nameof(UploadBook), new { isSuccess = true, BookID = (int)id });

                }

            }

            //function call to get languages from database
            ViewBag.Languages = await LanguageDropDown();
            return View();          
        }
        //..........................................................................................................//
       
            
         //...............................Lanaguage DropDown.........................................................//
        public async Task<List<SelectListItem>> LanguageDropDown()
        {
            var language = await languageRepository.GetLanguageList();

            List<SelectListItem> Languages = language.Select(x => new SelectListItem()
             {
                 Text = x.Name,
                 Value = x.LanguageID.ToString()
             }).ToList();

            return Languages;
        }

        //...............................Save Images to the folder......................................................//

        //save photo
        public async Task<string> SaveImage(string path, IFormFile file)
        {
            //create a file path with file name
            string  PhotoFile = path + Guid.NewGuid().ToString() + "_" +  file.FileName;
            //combine the photopath with server file
            string serverFolder = Path.Combine(webHostEnvironment.WebRootPath, PhotoFile);
            //save the file to image folder
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + PhotoFile;
        }
    }
}