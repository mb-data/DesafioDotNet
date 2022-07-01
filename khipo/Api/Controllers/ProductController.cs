using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class ProductController : ApiController
    {
        private static List<Product> produtos = new List<Product>();

        // GET
        public List<Product> Get()
        { 
            return produtos;
        }

        // GET ONE
        public Product GetProdutoId(int id)
        { 
            return produtos.FirstOrDefault(x => x.Id == id);
        }

        // DELETE 
        public void Delete(int id)
        {
            produtos.RemoveAt(produtos.IndexOf(produtos.First(x => x.Equals(id))));
        }

        // PUT
        public Product UpdateProduct(int id, Product produto)
        { 
            if (id == 0) 
            {
                throw new Exception('O valor de ID não pode ser zerado!');
            }
            
            return produtos.FirstOrDefault(x => x.Id == id);
        }
    }
}
