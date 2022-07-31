using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiDotNetFramework.Entities;
using ApiDotNetFramework.Repositories;

namespace ApiDotNetFramework.Tests
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        [TestCategory("Product")]
        public void Should_Create_Valid_Product()
        {
            var product = new ProductEntity("Test", "Test", 7.5);
            Assert.AreEqual(product.Name, "Test");
            Assert.AreEqual(product.Brand, "Test");
            Assert.AreEqual(product.Price, 7.5);
        }


        [TestMethod]
        [TestCategory("Product")]
        public void Should_Get_All_Products()
        {
            var repository = new FakeRepository();
            var listaProdutos = repository.GetAll();
            Assert.AreEqual(listaProdutos.Count,6);
        }

        [TestMethod]
        [TestCategory("Product")]
        public void Should_Get_Product_ById()
        {
            var repository = new FakeRepository();
            var produto = repository.GetById(2);
            Assert.AreEqual(produto.Id, 2);
            Assert.AreEqual(produto.Name, "Product02");
            Assert.AreEqual(produto.Brand, "Brand02");
            Assert.AreEqual(produto.Price, 2.5);
        }

        
        [TestMethod]
        [TestCategory("Product")]
        public void Should_Insert_New_Product()
        {
            var repository = new FakeRepository();
            var totalProducts = repository.listaProdutos.Count;
            var Id = totalProducts + 1;
            var product = new ProductEntity() {Name = "Product" + Id, Brand = "Brand" + Id, Price = 4.99 };
            repository.Insert(product);
            Assert.IsTrue(repository.listaProdutos.Count > totalProducts);
        }

        [TestMethod]
        [TestCategory("Product")]
        public void Should_Update_Product()
        {
            var repository = new FakeRepository();
            var totalProducts = repository.listaProdutos.Count;
            var Id = 3;
            var product = new ProductEntity() { Name = "ProductUpdated", Brand = "BrandUpdated", Price = 9.99 };
            repository.Update(product, Id);
            var Index = repository.listaProdutos.FindIndex(x => x.Id == Id);
            Assert.IsTrue(repository.listaProdutos[Index].Name == "ProductUpdated");
            Assert.IsTrue(repository.listaProdutos[Index].Brand == "BrandUpdated");
            Assert.IsTrue(repository.listaProdutos[Index].Price == 9.99);
        }

        [TestMethod]
        [TestCategory("Product")]
        public void Should_Delete_Product()
        {
            var repository = new FakeRepository();
            var totalProducts = repository.listaProdutos.Count;
            repository.Delete(2);
            Assert.IsTrue(repository.listaProdutos.Count < totalProducts);
        }
    }
}
