using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace PRN_Project.Pages.Admin.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Category Category { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            Category = _unitOfWork.Category.getFirstOrDefault(u => u.Id == id);
        }

        

        public async Task<IActionResult> OnPost()
        {
                var categoryFromDb = _unitOfWork.Category.getFirstOrDefault(u => u.Id == Category.Id);
            if (categoryFromDb != null)
                {
                _unitOfWork.Category.remove(categoryFromDb);
                _unitOfWork.save();
                TempData["success"] = "Category delete successfully !";
                return RedirectToPage("Index");
                }
                return Page();
        }
    }
}
