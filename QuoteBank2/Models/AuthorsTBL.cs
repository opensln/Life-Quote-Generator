using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuoteBank2.Models
{
    public class AuthorsTBL
    {
        [Key]
        public int AuthID { get; set; }

        [Required]
        [DisplayName("Author Name")]
        public string AuthorName { get; set; }

        [Required]
        public string AuthorImage { get; set; }

      
    }
}