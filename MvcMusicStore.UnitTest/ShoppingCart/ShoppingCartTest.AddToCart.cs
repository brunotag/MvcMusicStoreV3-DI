using System;
using System.Data.Entity;
using System.Linq;
using FakeDbSet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcMusicStore.Models;

namespace MvcMusicStore.UnitTest
{
    [TestClass]
    public class ShoppingCartTest_AddToCart
    {
        private IMusicStoreEntities Store
        {
            get { return _mockStore.Object; }
        }

        private Mock<IMusicStoreEntities> _mockStore;

        private Album _album;
        private const int _albumId = 42;

        private readonly string _shoppingCartId = Guid.NewGuid().ToString();

        private IDbSet<Cart> _carts;
        private Cart _addedCart;

        [TestInitialize]
        public void Setup()
        {
            _album = new Album()
            {
                AlbumId = _albumId
            };

            _addedCart = new Cart();

            _carts = new InMemoryDbSet<Cart>();

            _mockStore = new Mock<IMusicStoreEntities>();
            _mockStore.Setup(store => store.Carts).Returns(_carts);
        }

        [TestMethod]
        public void When_CartItemIsNotFound_Then_StoreShouldContainANewCartItem()
        {
            Setup_CartsWillBeEmpty();

            CallSut();

            _mockStore.VerifyGet(store => store.Carts, Times.Exactly(2));
            _mockStore.Verify(store => store.SaveChanges(), Times.Once());

            Assert.AreEqual(1, Store.Carts.Count(), string.Format("Store contains {0} objects instead of 1", Store.Carts.Count()));
            Assert.AreNotEqual(_addedCart, Store.Carts.Single());
        }

        private void Setup_CartsWillBeEmpty()
        {
        }

        private void Setup_CartsWillContainCurrentCart()
        {
            _carts.Add(_addedCart);
        }

        private void CallSut()
        {
            var sut = ShoppingCartFakeFactory.GetCart(_shoppingCartId, Store);
            sut.AddToCart(_album);
        }
    }
}
