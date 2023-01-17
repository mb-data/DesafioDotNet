using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ProductsController : ApiController
    {
        // GET /api/v1/products Retorna todos os produtos em lista
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET /api/v1/products/:productId Retorna apenas o produto do productId
        public string Get(int id)
        {
            return "value";
        }

        // POST /api/v1/products Salva o produto e retorna ele
        public void Post([FromBody] string value)
        {
        }

        // PUT /api/v1/products/:productId
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE /api/v1/products/:productId
        public void Delete(int id)
        {
        }
    }
}
