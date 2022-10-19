using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN_Project.Data;
using PRN_Project.Model;

namespace PRN_Project.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        public Category Category { get; set; }

        public void OnGet()
        {

        }

        public CreateModel(ApplicationDbContext db)
        {
            dbContext = db;
        }

        public async Task<IActionResult> OnPost()
        {
            await dbContext.Category.AddAsync(Category);
            await dbContext.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
