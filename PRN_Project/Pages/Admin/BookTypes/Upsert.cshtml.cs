using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace PRN_Project.Pages.Admin.BookTypes
{
    [BindProperties]
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookType BookType { get; set; }

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            BookType = new();
        }

        //edit
        public void OnGet(int? id)
        {
            if (id != null)
            {
                BookType = _unitOfWork.BookType.getFirstOrDefault(u => u.Id == id);
            }
        }

        public async Task<IActionResult> OnPost()
        {
            //create
            if (BookType.Id == 0)
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.BookType.add(BookType);
                    _unitOfWork.save();
                    TempData["success"] = "Book type create successfully !";
                    return RedirectToPage("Index");
                }
            }
            else //edit
            {
                var obj = _unitOfWork.BookType.getFirstOrDefault(u => u.Id == BookType.Id);               
                if (ModelState.IsValid)
                {
                    _unitOfWork.BookType.update(BookType);
                    _unitOfWork.save();
                    TempData["success"] = "Category update successfully !";
                    return RedirectToPage("Index");
                }
            }
            return Page();
        }
    }
}
