using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using QuoteBank2.Models;

namespace QuoteBank2.ViewModels
{
    public class AuthorFormViewModel
    {
        [Required(ErrorMessage = "You need to enter the Author Name.")]
        [DisplayName("Enter Author Name:")]
        public string AuthorNameVM { get; set; }

        //HttpPostedFileBase to upload the actaual imageFile
        [Required(ErrorMessage = "You need to upload an image.")]
        [DisplayName("Upload an Image:")]
        public HttpPostedFileBase ImageFileVM { get; set; } //We need this here to avoid a column being created by codeFirst migration
        //If this was in the original model it would have created column - we already have an AuthorImage column.

        //public string AuthorImageVM { get; set; } //Left over from testing viewModelversion
        //public int AuthorNameINTVM { get; set; } //Left over from testing viewModelVersion


    }
}