using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please enter a Title")]   
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter an Author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Please enter a Publisher")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Please enter an ISBN")]
        [RegularExpression(@"^\d{3}[-]\d{10}$", ErrorMessage = "That ISBN isn't valid")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Please enter a Classification")]
        public string Classification { get; set; }

        [Required(ErrorMessage = "Please enter a Category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please enter a Price")]
        public double Price { get; set; }

    }
}
