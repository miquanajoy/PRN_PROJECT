using BookStore.DataAccess.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace PRN_Project.Pages.Admin.Categories
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
                ModelState.AddModelError("Category.Name", "Name can't exactly match with display order");
            }
            if(ModelState.IsValid)
            {
                await dbContext.Category.AddAsync(Category);
                await dbContext.SaveChangesAsync();
                TempData["success"] = "Category create successfully !";
                return RedirectToPage("Index");
            }
            return Page();
            
        }
    }
}
