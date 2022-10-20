using BookStore.DataAccess.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace PRN_Project.Pages.Admin.BookTypes
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        public BookType BookType { get; set; }

        public void OnGet(int id)
        {
            BookType = dbContext.BookType.FirstOrDefault(u=>u.Id==id);
        }

        public EditModel(ApplicationDbContext db)
        {
            dbContext = db;
        }

        public async Task<IActionResult> OnPost()
        {
            
            if(ModelState.IsValid)
            {
                dbContext.BookType.Update(BookType);
                await dbContext.SaveChangesAsync();
                TempData["success"] = "Book type update successfully !";
                return RedirectToPage("Index");
            }
            return Page();
            
        }
    }
}
