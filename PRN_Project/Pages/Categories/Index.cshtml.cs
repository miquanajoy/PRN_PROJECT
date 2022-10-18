using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN_Project.Data;
using PRN_Project.Model;

namespace PRN_Project.Pages.Categories
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
