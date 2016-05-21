using MvcMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore
{
    public class ShoppingCartFactory : IShoppingCartFactory
    {
        private IMusicStoreEntities _store;
        private HttpContext _httpContext;

        public ShoppingCartFactory(HttpContext httpContext, IMusicStoreEntities store)
        {
            _httpContext = httpContext;
            _store = store;
        }

        public Models.ShoppingCart GetCart()
        {
            throw new NotImplementedException();
        }
    }
}