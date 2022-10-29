using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using BookStore.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;

namespace PRN_Project.Pages.Customer.Cart
{
    [Authorize]
    [BindProperties]
    public class SummaryModel : PageModel
    {
        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }
        public OrderHeader OrderHeader { get; set; }

        private readonly IUnitOfWork _unitOfWork;
        public SummaryModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            OrderHeader = new OrderHeader();
        }

        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.getAll(
                    filter: u => u.ApplicationUserId == claim.Value,
                    includeProperties: "MenuItem,MenuItem.BookType,MenuItem.Category");

                foreach (var cartItem in ShoppingCartList)
                {
                     OrderHeader.OrderTotal += (cartItem.MenuItem.Price * cartItem.Count);
                }
                ApplicationUser applicationUser = _unitOfWork.ApplicationUser.getFirstOrDefault(
                    u => u.Id == claim.Value);
                OrderHeader.PickUpName = applicationUser.FirstName + " " + applicationUser.LastName;
                OrderHeader.PhoneNumber = applicationUser.PhoneNumber;
            }
        }

        public void OnPost()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.getAll(
                    filter: u => u.ApplicationUserId == claim.Value,
                    includeProperties: "MenuItem,MenuItem.BookType,MenuItem.Category");

                foreach (var cartItem in ShoppingCartList)
                {
                    OrderHeader.OrderTotal += (cartItem.MenuItem.Price * cartItem.Count);
                }
                OrderHeader.Status=SD.StatusPending;
                OrderHeader.OrderDate = System.DateTime.Now;
                OrderHeader.UserId = claim.Value;
                OrderHeader.PickUpTime = Convert.ToDateTime(
                    OrderHeader.PickUpDate.ToShortDateString() + " " +
                    OrderHeader.PickUpTime.ToShortTimeString());
                _unitOfWork.OrderHeader.add(OrderHeader);
                _unitOfWork.save();
            
                foreach(var item in ShoppingCartList)
                {
                    OrderDetails orderDetails = new()
                    {
                        MenuItemId = item.MenuItemId,
                        OrderId = OrderHeader.Id,
                        Name = item.MenuItem.Name,
                        Price = item.MenuItem.Price,
                        Count = item.Count
                    };
                    _unitOfWork.OrderDetails.add(orderDetails);
                }

                _unitOfWork.ShoppingCart.removeRange(ShoppingCartList);
                _unitOfWork.save();
            }
        }


    }
}
