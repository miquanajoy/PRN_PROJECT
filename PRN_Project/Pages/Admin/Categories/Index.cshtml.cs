using BookStore.DataAccess.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace PRN_Project.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        public IEnumerable<Category> categories { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            dbContext = db;
        }

        public void OnGet()
        {
            categories = dbContext.Category;
        }
    }
}
