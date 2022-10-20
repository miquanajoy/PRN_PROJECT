using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace PRN_Project.Pages.Admin.BookTypes
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookType BookType { get; set; }

        public void OnGet(int id)
        {
            BookType = _unitOfWork.BookType.getFirstOrDefault(u => u.Id == id);
        }

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> OnPost()
        {
            
            if(ModelState.IsValid)
            {
                _unitOfWork.BookType.update(BookType);
                _unitOfWork.save();
                TempData["success"] = "Book type update successfully !";
                return RedirectToPage("Index");
            }
            return Page();
            
        }
    }
}
