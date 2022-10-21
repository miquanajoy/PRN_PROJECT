using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class MenuItem
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string description { get; set; }
        [Range(1, 1000,ErrorMessage = "Price should be between $1 - $1000")]
        public string image { get; set; }
        public double price { get; set; }
        public int bookTypeId { get; set; }
        [ForeignKey("bookTypeId")]
        public BookType bookType { get; set; }
        public int categoryId { get; set; }
        public Category category { get; set; }



    }
}
