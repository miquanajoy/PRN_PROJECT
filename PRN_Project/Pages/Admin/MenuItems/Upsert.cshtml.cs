using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PRN_Project.Pages.Admin.MenuItems
{
    [BindProperties]
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MenuItem MenuItem { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> BookTypeList { get; set; }

        public void OnGet(int? id)
        {
            if (id != null)
            {
                //edit
                MenuItem = _unitOfWork.MenuItem.getFirstOrDefault(u => u.Id == id);
            }
            CategoryList = _unitOfWork.Category.getAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),

            });

            BookTypeList = _unitOfWork.BookType.getAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),

            });

        }

        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            MenuItem = new();
        }

        public async Task<IActionResult> OnPost()
        {

            string webRootPath = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files; 
            if (MenuItem.Id == 0)
            {
                //create
                string fileName_new = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"image\menuItems");
                var extension = Path.GetExtension(files[0].FileName);

                using(var fileStream = new FileStream(Path.Combine(uploads, fileName_new+extension), 
                            FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                MenuItem.Image = @"\image\menuItems\" + fileName_new + extension;
                _unitOfWork.MenuItem.add(MenuItem);
                _unitOfWork.save();
            } 
            else
            {
                var obj = _unitOfWork.MenuItem.getFirstOrDefault(u => u.Id == MenuItem.Id);
                if (files.Count > 0)
                {
                    string fileName_new = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"image\menuItems");
                    var extension = Path.GetExtension(files[0].FileName);

                    //delete old img
                    var oldImagePath = Path.Combine(webRootPath, obj.Image.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                    //new upload
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension),
                                FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    MenuItem.Image = @"\image\menuItems\" + fileName_new + extension;
                }
                else
                {
                    MenuItem.Image = obj.Image;
                }

                _unitOfWork.MenuItem.update(MenuItem);
                _unitOfWork.save();
            }
            return RedirectToPage("./Index");

        }
    }
}
