using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using BookStore.Models.ViewModel;
using BookStore.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN_Project.Pages.Admin.Order
{
    public class ManageOrderModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public List<OrderDetailsVM> OrderDetailsVM {get; set;}

        public ManageOrderModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            OrderDetailsVM = new();

            List<OrderHeader> orderHeaders = _unitOfWork.OrderHeader.getAll(u => u.Status == SD.StatusSubimitted ||
            u.Status == SD.StatusInProcess).ToList();

            foreach(OrderHeader item in orderHeaders)
            {
                OrderDetailsVM individual = new OrderDetailsVM()
                {
                    OrderHeader = item,
                    OrderDetails = _unitOfWork.OrderDetails.getAll(u => u.OrderId == item.Id).ToList()
                };
                OrderDetailsVM.Add(individual);
            }
            
        }
    }
}
