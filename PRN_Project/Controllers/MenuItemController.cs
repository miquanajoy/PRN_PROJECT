using BookStore.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PRN_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var menuItemList = _unitOfWork.MenuItem.getAll(includeProperties: "BookType,Category");
            return Json(new {data = menuItemList});
        }
    }
}
