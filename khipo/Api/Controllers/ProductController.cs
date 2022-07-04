using Api.Models;
using Api.Repositrorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Api.Controllers
{
    public class ProductController : ApiController
    {
        private static List<Product> produtos = new List<Product>();
        private ProdutoRepositorio _repositorio;

        // POST
        public void Post(Product product)
        {
            _repositorio = new ProdutoRepositorio();
            if(!string.IsNullOrEmpty(product.Name) || 
                !string.IsNullOrEmpty(product.Brand))
            _repositorio.AdicionarProduct(product);
        }
        // GET
        public List<Product> Get()
        {
            _repositorio = new ProdutoRepositorio();
            return _repositorio.ObterProductos();

        }

        // GET ONE
        public Product produto Get(int id)
        {
            produto = new Product();
            return produto;
        }  

        // PUT
        public void UpdateProduct(int id, Product produto)
        {
            _repositorio = new ProdutoRepositorio();

            if (id <= 0) 
            {
                throw new Exception("Identificado não pode ser menor que zero!");
            }

        }

        // DELETE 
        public bool Delete(int id)
        {
            _repositorio = new ProdutoRepositorio();
           var i =  _repositorio.ExcluirProduct(id);
            return i;   
        }
    }
}
