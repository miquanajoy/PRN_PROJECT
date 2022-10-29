using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace PRN_Project.Pages.Customer.Cart
{
    [Authorize]
    public class IndexModel : PageModel
    {

        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }
        public double CartTotal { get; set; }

        private readonly IUnitOfWork _unitOfWork;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CartTotal = 0;
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
                    CartTotal += (cartItem.MenuItem.Price * cartItem.Count);
                }
            }
        }

        public IActionResult OnPostPlus(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.getFirstOrDefault(u => u.Id == cartId);
            _unitOfWork.ShoppingCart.incrementCount(cart, 1);
            return RedirectToPage("/Customer/Cart/Index");
        }

        public IActionResult OnPostMinus(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.getFirstOrDefault(u => u.Id == cartId);
            if (cart.Count == 1)
            {
                _unitOfWork.ShoppingCart.remove(cart);
                _unitOfWork.save();
            }
            else
            {
                _unitOfWork.ShoppingCart.decrementCount(cart, 1);

            }

            return RedirectToPage("/Customer/Cart/Index");
        }

        public IActionResult OnPostRemove(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.getFirstOrDefault(u => u.Id == cartId);
            _unitOfWork.ShoppingCart.remove(cart);
            _unitOfWork.save();
            return RedirectToPage("/Customer/Cart/Index");
        }
    }
}
