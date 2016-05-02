using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcMusicStore.Models;

namespace MvcMusicStore.UnitTest
{
    [TestClass]
    public class ShoppingCartTest_AddToCart
    {
        private IMusicStoreEntities _store;
        private Album _album;
        private int _albumId = 42;

        [TestInitialize]
        public void Setup()
        {
            _album = new Album()
            {
                AlbumId = _albumId
            };


        }

        private void CallSut()
        {
            var sut = new ShoppingCart(_store);
            sut.AddToCart(_album);
        }
    }
}
