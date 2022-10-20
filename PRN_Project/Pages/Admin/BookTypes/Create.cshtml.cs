using BookStore.DataAccess.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace PRN_Project.Pages.Admin.BookTypes
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        public BookType BookType { get; set; }

        public void OnGet()
        {

        }

        public CreateModel(ApplicationDbContext db)
        {
            dbContext = db;
        }

        public async Task<IActionResult> OnPost()
        {
           
            if(ModelState.IsValid)
            {
                await dbContext.BookType.AddAsync(BookType);
                await dbContext.SaveChangesAsync();
                TempData["success"] = "Book type create successfully !";
                return RedirectToPage("Index");
            }
            return Page();
            
        }
    }
}
