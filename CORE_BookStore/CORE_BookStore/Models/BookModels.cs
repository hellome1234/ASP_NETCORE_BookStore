using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CORE_BookStore.Helpers;
using Microsoft.AspNetCore.Http;

namespace CORE_BookStore.Models
{
    public class BookModels
    {
        public long BookID { get; set; }

        [BookValidation("Book must contan MVC in its name")]
        [Display(Name = "Book Name")]
        [Required(ErrorMessage ="You must provide a book name")]
        public String BookName { get; set; }

        [Required(ErrorMessage = "You forgot to mention the auther of the book!")]
        [Display(Name = "Auther Name")]
        public String AurtherName { get; set; }

        public String Discription { get; set; }

        [RegularExpression((@"^[a-zA-Z]*$"),ErrorMessage ="You are only allowed to include Standard Alphabet characters!")]
        public String Genre { get; set; }
       
        [Display(Name ="Total Pages")]
        public int TotalPage { get; set; }
       
        [Required(ErrorMessage = "Please Provide the book language!")]
        [Display(Name = "Available Language")]
        public int LanguageID { get; set; }

        public string Language { get; set; }

        [Display(Name ="Cover Photo")]
        [Required(ErrorMessage = "Your must provide a cover photo!")]
        public IFormFile CoverPhotoFile { get; set; }

        public string BookCoverPhoto { get; set; }

        [Display(Name ="Choose the gallery Images for your book")]
        [Required]
        public IFormFileCollection BookGalleries { get; set; }

        public List<BookGalleryModels> BookGallery { get; set; }

        [Display(Name ="PDF File")]
        [Required(ErrorMessage ="You must provide the book pdf file")]
        public IFormFile BookPDF { get; set; }

        public string BookURL { get; set; }



    }
}
