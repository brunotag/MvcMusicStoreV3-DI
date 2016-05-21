using MvcMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore
{
    public interface IShoppingCartFactory
    {
        ShoppingCart GetCart();
    }
}