using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuoteBank2.Models
{
    public class QuotesTBL
    {
        [Key]
        public int QuoteID { get; set; }

        [Required(ErrorMessage = "Please enter the Quote")]
        public string Quote { get; set; }
       
        public virtual AuthorsTBL AuthorsTBL { get; set; }

        [Required(ErrorMessage = "Please select an Author")]
        public int AuthorsTBLAuthID { get; set; }


    }
}