using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace MvcMusicStore.Models
{
    interface IMusicStoreEntities
    {
        IDbSet<Album> Albums { get; set; }
        IDbSet<Genre> Genres { get; set; }
        IDbSet<Artist> Artists { get; set; }
        IDbSet<Cart> Carts { get; set; }
        IDbSet<Order> Orders { get; set; }
        IDbSet<OrderDetail> OrderDetails { get; set; }
    }
}
