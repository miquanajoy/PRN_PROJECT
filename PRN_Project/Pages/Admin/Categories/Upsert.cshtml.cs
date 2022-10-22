using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN_Project.Pages.Admin.Categories
{
    [BindProperties]
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public Category Category { get; set; }

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Category = new();
        }
        //edit
        public void OnGet(int? id)
        {
            if (id != null)
            {
                Category = _unitOfWork.Category.getFirstOrDefault(u => u.Id == id);
            }
        }
        public async Task<IActionResult> OnPost()
        {
            //create
            if (Category.Id == 0)
            {
                if (Category.Name == Category.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("Category.Name", "Name can't exactly match with display order");
                }
                if (ModelState.IsValid)
                {
                    _unitOfWork.Category.add(Category);
                    _unitOfWork.save();
                    TempData["success"] = "Category create successfully !";
                    return RedirectToPage("Index");
                }
            } 
            else //edit
            {
                var obj = _unitOfWork.Category.getFirstOrDefault(u => u.Id == Category.Id);
                if (Category.Name == Category.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("Category.Name", "Name can't exactly match with display order");
                }
                if (ModelState.IsValid)
                {
                    _unitOfWork.Category.update(Category);
                    _unitOfWork.save();
                    TempData["success"] = "Category update successfully !";
                    return RedirectToPage("Index");
                }
            }
            return Page();
        }


    }
}
