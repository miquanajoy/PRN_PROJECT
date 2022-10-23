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

        public MenuItem MenuItem { get; set; }

        [Range(1, 100, ErrorMessage = "You can only buy 1-100")]
        public int count { get; set; }

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            MenuItem = _unitOfWork.MenuItem.getFirstOrDefault(u=>u.Id == id, includeProperties: "BookType,Category");
        }
    }
}
