using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using QuoteBank2.Models;

namespace QuoteBank2.ViewModels
{
    public class QuoteFormViewModel
    {
        [Required(ErrorMessage = "You need enter the quote text(VM).")]
        [DisplayName("Enter Quote Here:")]
        public string QuoteVM { get; set; }

        public IEnumerable<AuthorsTBL> AuthorsListable { get; set; }

        //public int AuthorsTBLAuthIDVM { get; set; } //Left over from view model version to provide the int to the foreign key

    }
}