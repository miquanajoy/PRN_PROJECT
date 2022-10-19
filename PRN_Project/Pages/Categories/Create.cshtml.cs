using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN_Project.Model;

namespace PRN_Project.Pages.Categories
{
    public class CreateModel : PageModel
    {

        public Category categories { get; set; }

        public void OnGet()
        {
        }
    }
}
