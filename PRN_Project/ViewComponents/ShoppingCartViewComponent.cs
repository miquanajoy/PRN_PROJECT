using BookStore.DataAccess.Repository.IRepository;
using BookStore.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PRN_Project.ViewComponents
{
    public class ShoppingCartViewComponent: ViewComponent
    {

        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            int count = 0;
            if (claim != null)
            {
                //user log in
                if(HttpContext.Session.GetInt32(SD.SessionCart) != null)
                {
                    return View(HttpContext.Session.GetInt32(SD.SessionCart));
                } else
                {
                    count = _unitOfWork.ShoppingCart.getAll(x => x.ApplicationUserId == claim.Value).ToList().Count;
                    HttpContext.Session.SetInt32(SD.SessionCart, count);
                    return View(count);
                }
            } else
            {
                HttpContext.Session.Clear();
                //user has not log in
                return View(count);
            }
        }
    }
}
