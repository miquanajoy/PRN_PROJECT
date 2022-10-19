using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN_Project.Data;
using PRN_Project.Model;

namespace PRN_Project.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        public Category Category { get; set; }

        public void OnGet(int id)
        {
            Category = dbContext.Category.FirstOrDefault(u=>u.Id==id);
        }

        public EditModel(ApplicationDbContext db)
        {
            dbContext = db;
        }

        public async Task<IActionResult> OnPost()
        {
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "Name can't exactly match with display order");
            }
            if(ModelState.IsValid)
            {
                dbContext.Category.Update(Category);
                await dbContext.SaveChangesAsync();
                TempData["success"] = "Category update successfully !";
                return RedirectToPage("Index");
            }
            return Page();
            
        }
    }
}
