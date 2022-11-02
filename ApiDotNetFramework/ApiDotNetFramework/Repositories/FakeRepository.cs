using ApiDotNetFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiDotNetFramework.Repositories
{
    public class FakeRepository
    {
        public List<ProductEntity> listaProdutos;

        public FakeRepository()
        {
            listaProdutos = new List<ProductEntity>();
            listaProdutos.Add(new ProductEntity() { Id = 1, Name = "Product01", Brand = "Brand01", Price = 2.0 });
            listaProdutos.Add(new ProductEntity() { Id = 2, Name = "Product02", Brand = "Brand02", Price = 2.5 });
            listaProdutos.Add(new ProductEntity() { Id = 3, Name = "Product03", Brand = "Brand03", Price = 1.2 });
            listaProdutos.Add(new ProductEntity() { Id = 4, Name = "Product04", Brand = "Brand04", Price = 7.7 });
            listaProdutos.Add(new ProductEntity() { Id = 5, Name = "Product05", Brand = "Brand05", Price = 4.3 });
            listaProdutos.Add(new ProductEntity() { Id = 6, Name = "Product06", Brand = "Brand06", Price = 5.1 });
        }
        
        public List<ProductEntity> GetAll()
        {
                return listaProdutos;
        }

        public ProductEntity GetById(int id)
        {
                return listaProdutos.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(ProductEntity entity)
        {
            var maxId = listaProdutos.Max(t => t.Id);
            maxId++;

            var produto = new ProductEntity(){
                Id = maxId,
                Name = entity.Name,
                Brand = entity.Brand,
                Price = entity.Price,
                CreatedAt = DateTime.Now
            };
            listaProdutos.Add(produto);
            return maxId;
        }

        public void Update(ProductEntity entity, int id)
        {
            var index = listaProdutos.FindIndex(t => t.Id == id);

            if (index != null)
            {
                listaProdutos[index].Name = entity.Name;
                listaProdutos[index].Brand = entity.Brand;
                listaProdutos[index].Price = entity.Price;
                listaProdutos[index].UpdatedAt = DateTime.Now;
            }
        }

        public void Delete(int id)
        {
            var index = listaProdutos.FindIndex(t => t.Id == id);

            if (index != null)
            {
                listaProdutos.RemoveAt(index);
               
            }
        }
    }
}