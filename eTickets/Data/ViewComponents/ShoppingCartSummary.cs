﻿using eTickets.Data.Cart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eTickets.Data.ViewComponents
{
    public class ShoppingCartSummary:ViewComponent
    {
        public ShoppingCart _shoppingCart;
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }
        public IViewComponentResult Invoke()
        {
            var items=_shoppingCart.GetShoppingCartItems();
            return View(items.Count);
        }
    }
}
