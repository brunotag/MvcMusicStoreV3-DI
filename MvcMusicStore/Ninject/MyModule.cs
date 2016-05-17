using MvcMusicStore.Models;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Ninject
{
    public class MyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMusicStoreEntities>().To<MusicStoreEntities>().InRequestScope();
        }
    }
}