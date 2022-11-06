using BookStore.DataAccess.Repository.IRepository;
using BookStore.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PRN_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get(string? status=null)
        {
            var OrderHeaderList = _unitOfWork.OrderHeader.getAll(includeProperties:"ApplicationUser");

            if(status == "cancelled")
            {
                OrderHeaderList = OrderHeaderList.Where(x => x.Status == SD.StatusCancelled || x.Status == SD.StatusRejected);
            } 
            else
            {
                if (status == "completed")
                {
                    OrderHeaderList = OrderHeaderList.Where(x => x.Status == SD.StatusCompleted);
                }
                else
                {
                    if (status == "ready")
                    {
                        OrderHeaderList = OrderHeaderList.Where(x => x.Status == SD.StatusReady);
                    } 
                    else
                    {
                        OrderHeaderList = OrderHeaderList.Where(x => x.Status == SD.StatusSubimitted ||  
                        x.Status == SD.StatusInProcess);
                    }
                }
            }
            return Json(new {data = OrderHeaderList});
        }

        
    }
}
