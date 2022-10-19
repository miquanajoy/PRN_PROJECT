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
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(String.Empty, "Name can't exactly match with display order");
            }
            if(ModelState.IsValid)
            {
                await dbContext.Category.AddAsync(Category);
                await dbContext.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
            
        }
    }
}
