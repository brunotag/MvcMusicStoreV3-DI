using MvcMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcMusicStore.UnitTest
{
    static class ShoppingCartFakeFactory
    {
        public static ShoppingCart GetCart(string cartId, IMusicStoreEntities store)
        {
            var cart = new ShoppingCart(store) { ShoppingCartId = cartId };
            return cart;
        }
    }
}
