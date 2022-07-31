using ApiDotNetFramework.Entities;
using ApiDotNetFramework.Repositories;
using ApiDotNetFramework.ViewModels;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiDotNetFramework.Controllers
{
    public class ProductController : ApiController
    {
        private SqlServerRepository respository = new SqlServerRepository();

        [HttpGet]
        [Route("api/v1/products")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = respository.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, new ResultViewModel<dynamic>(data));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Internal server error");
            }
        }

        [HttpGet]
        [Route("api/v1/products/{productId}")]
        public HttpResponseMessage GetById(
            [FromUri] int productId)
        {
            try
            {
                var data = respository.GetById(productId);
                return Request.CreateResponse(HttpStatusCode.OK, new ResultViewModel<dynamic>(data));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Internal server error");
            }
        }


        [HttpPost]
        [Route("api/v1/products")]
        public HttpResponseMessage Post(ProductEntity product)
        {

            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            try
            {
                var id = respository.Insert(product);
                product.Id = id;
                product.CreatedAt = DateTime.Now;
                return Request.CreateResponse(HttpStatusCode.Created, new ResultViewModel<dynamic>(product));
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error to create product. ");
            }
        }

        [HttpPut]
        [Route("api/v1/products/{productId}")]
        public HttpResponseMessage Put(
            ProductEntity product,
            [FromUri] int productId)
        {

            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            try
            {
                var data = respository.GetById(productId);
                if (data == null)
                    return Request.CreateResponse(HttpStatusCode.NoContent, new ResultViewModel<dynamic>(data));

                data.Name = product.Name;
                data.Brand = product.Brand;
                data.Price = product.Price;
                data.UpdatedAt = DateTime.Now;
                respository.Update(data, productId);
                
                return Request.CreateResponse(HttpStatusCode.OK, new ResultViewModel<dynamic>(data));
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error to update product. ");
            }
        }


        [HttpDelete]
        [Route("api/v1/products/{productId}")]
        public HttpResponseMessage Delete(
            [FromUri] int productId)
        {
            try
            {
                var data = respository.GetById(productId);
                if(data == null)
                    return Request.CreateResponse(HttpStatusCode.NoContent, new ResultViewModel<dynamic>(data));

                respository.Delete(productId);
                return Request.CreateResponse(HttpStatusCode.OK, new ResultViewModel<dynamic>(""));
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error to update product. ");
            }
        }

    }
}