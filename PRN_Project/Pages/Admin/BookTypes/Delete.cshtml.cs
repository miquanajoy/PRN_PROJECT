using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace PRN_Project.Pages.Admin.BookTypes
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookType BookType { get; set; }

        public void OnGet(int id)
        {
            BookType = _unitOfWork.BookType.getFirstOrDefault(u => u.Id == id);
        }

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> OnPost()
        {
                var bookTypeFromDb = _unitOfWork.BookType.getFirstOrDefault(u=> u.Id == BookType.Id);
                if (bookTypeFromDb != null)
                {
                    _unitOfWork.BookType.remove(bookTypeFromDb);
                    _unitOfWork.save();
                    TempData["success"] = "Book type delete successfully !";
                    return RedirectToPage("Index");
                }
                return Page();
        }
    }
}
