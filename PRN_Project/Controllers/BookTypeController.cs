using BookStore.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PRN_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public IActionResult Get()
        {
            var bookTypeList = _unitOfWork.BookType.getAll();
            return Json(new { data = bookTypeList });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.BookType.getFirstOrDefault(u => u.Id == id);

            _unitOfWork.BookType.remove(obj);
            _unitOfWork.save();
            return Json(new { success = true, message = "Delete successful!" });
        }
    }
}
