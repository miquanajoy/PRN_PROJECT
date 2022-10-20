using BookStore.DataAccess.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace PRN_Project.Pages.Admin.BookTypes
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        public BookType BookType { get; set; }

        public void OnGet(int id)
        {
            BookType = dbContext.BookType.Find(id);
        }

        public DeleteModel(ApplicationDbContext db)
        {
            dbContext = db;
        }

        public async Task<IActionResult> OnPost()
        {
                var bookTypeFromDb = dbContext.BookType.Find(BookType.Id);
                if (bookTypeFromDb != null)
                {
                    dbContext.BookType.Remove(bookTypeFromDb);
                    await dbContext.SaveChangesAsync();
                TempData["success"] = "Book type delete successfully !";
                return RedirectToPage("Index");
                }
                return Page();
        }
    }
}
