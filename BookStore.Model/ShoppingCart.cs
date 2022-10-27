using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        [Range(1, 100, ErrorMessage = "You can only buy 1-100")]
        public int Count { get; set; }
        public int MenuItemId { get; set; }
        [ForeignKey("MenuItemId")]
        [NotMapped]
        [ValidateNever]
        public MenuItem MenuItem { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [NotMapped]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

    }
}
