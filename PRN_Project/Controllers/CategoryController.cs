using BookStore.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PRN_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            var categoryList = _unitOfWork.Category.getAll();
            return Json(new { data = categoryList });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.Category.getFirstOrDefault(u => u.Id == id);

            _unitOfWork.Category.remove(obj);
            _unitOfWork.save();
            return Json(new { success = true, message = "Delete successful!" });
        }
    }
}
