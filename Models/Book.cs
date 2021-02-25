using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    // Creates the Book model that we then use in the Database
    // Defines each property to be Required
    public class Book
    {

        // makes BookId the primary key
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please enter a Title")]   
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter an Author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Please enter a Publisher")]
        public string Publisher { get; set; }

        // Validates the ISBN to make sure it fits the format ###-##########
        [Required(ErrorMessage = "Please enter an ISBN")]
        [RegularExpression(@"^\d{3}[-]\d{10}$", ErrorMessage = "That ISBN isn't valid")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Please enter a Classification")]
        public string Classification { get; set; }

        [Required(ErrorMessage = "Please enter a Category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please enter a Price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please enter the number of Pages")]
        public int Pages { get; set; }
        
    }
}
