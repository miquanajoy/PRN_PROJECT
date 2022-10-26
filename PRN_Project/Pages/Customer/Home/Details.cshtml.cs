using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace PRN_Project.Pages.Customer.Home
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [BindProperty]
        public ShoppingCart ShoppingCart { get; set; }

       
        public void OnGet(int id)
        {
            ShoppingCart = new()
            {
                MenuItem = _unitOfWork.MenuItem.getFirstOrDefault(u => u.Id == id, includeProperties: "BookType,Category")
            };
        }
    }
}
