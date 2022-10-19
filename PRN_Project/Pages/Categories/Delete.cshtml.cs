using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN_Project.Data;
using PRN_Project.Model;

namespace PRN_Project.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        public Category Category { get; set; }

        public void OnGet(int id)
        {
            Category = dbContext.Category.Find(id);
        }

        public DeleteModel(ApplicationDbContext db)
        {
            dbContext = db;
        }

        public async Task<IActionResult> OnPost()
        {
                var categoryFromDb = dbContext.Category.Find(Category.Id);
                if (categoryFromDb != null)
                {
                    dbContext.Category.Remove(categoryFromDb);
                    await dbContext.SaveChangesAsync();
                TempData["success"] = "Category delete successfully !";
                return RedirectToPage("Index");
                }
                return Page();
        }
    }
}
