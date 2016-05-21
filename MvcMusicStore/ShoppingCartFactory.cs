using MvcMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore
{
    public class ShoppingCartFactory : IShoppingCartFactory
    {
        public const string CartSessionKey = "CartId";

        private IMusicStoreEntities _store;
        private HttpContext _httpContext;

        public ShoppingCartFactory(HttpContext httpContext, IMusicStoreEntities store)
        {
            _httpContext = httpContext;
            _store = store;
        }

        public Models.ShoppingCart GetCart()
        {
            var cart = new ShoppingCart(_store);
            cart.ShoppingCartId = GetCartId();
            return cart;
        }

        private string GetCartId()
        {
            if (_httpContext.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(_httpContext.User.Identity.Name))
                {
                    _httpContext.Session[CartSessionKey] = _httpContext.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();

                    // Send tempCartId back to client as a cookie
                    _httpContext.Session[CartSessionKey] = tempCartId.ToString();
                }
            }

            return _httpContext.Session[CartSessionKey].ToString();
        }
    }
}