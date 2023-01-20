using ProductAPI.Data;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data.Common;
using static Dapper.SqlMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;

namespace ProductAPI.Services
{

    public interface IProductService : IDisposable
    {
        DbConnection GetDbConnection();
        public Task<List<Product>?> GetAllGetProducts();
        public Task<Product?> GetProductById(int productId);
        public Task<Product?> AddProduct(Product product);
        public Task<Product?> UpdateProduct(Product product);
        public Task<bool> DeleteProduct(int product);
    }

    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly string selectProcedure = "pr_product_sel";

        public ProductService(DataContext context)
        {
            _context = context;

        }

        public void Dispose() { }

        public DbConnection GetDbConnection()
        {
            return new SqlConnection(_context.Database.GetConnectionString());
        }

        public async Task<List<Product>?> GetAllGetProducts()
        {
            var result = await GetProducts(null);
            List<Product>? products = new();

            if (result.Count() > 0)
            {
                products = result.Select(p => new Product
                {
                    ProductId = p.productId,
                    Name = p.name,
                    Price = p.price,
                    Brand = p.brand,
                    CreateDate = p.createDate,
                    UpdateDate = p.updateDate

                }).ToList();
            }
            else
            {
                return null;
            }

            return products;
        }

        public async Task<Product?> GetProductById(int productId)
        {
            var result = await GetProducts(productId);
            Product? product = new();

            if (result.Count() > 0)
            {
                product = result.Select(p => new Product
                {
                    ProductId = p.productId,
                    Name = p.name,
                    Price = p.price,
                    Brand = p.brand,
                    CreateDate = p.createDate,
                    UpdateDate = p.updateDate

                }).First();
            }
            else
            {
                return null;
            }

            return product;
        }

        public async Task<Product?> AddProduct(Product product)
        {
            Product? selectProduct = new();
            try
            {
                using (_context)
                {
                    _context.Product.Add(product);
                    var nChanges = await _context.SaveChangesAsync();

                    if (nChanges == 1)
                    {
                        selectProduct = await _context.Product.FindAsync(product.ProductId);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }

            return selectProduct;
        }

        public async Task<Product?> UpdateProduct(Product product)
        {
            Product? selectProduct = new();

            try
            {
                using (_context)
                {
                    selectProduct = await _context.Product.FindAsync(product.ProductId);
                    if (selectProduct is null)
                        return null;

                    selectProduct.Name = product.Name;
                    selectProduct.Price = product.Price;
                    selectProduct.Brand = product.Brand;
                    selectProduct.CreateDate = selectProduct.CreateDate;
                    selectProduct.UpdateDate = DateTime.Now;

                    var nChanges = await _context.SaveChangesAsync();

                    if (nChanges == 1)
                    {
                        selectProduct = await _context.Product.FindAsync(product.ProductId);
                    }
                    else
                    {
                        return null;
                    }

                }
            }
            catch
            {
                return null;
            }

            return selectProduct;
        }

        public async Task<bool> DeleteProduct(int product)
        {
            Product? selectProduct = new();
            try
            {
                using (_context)
                {
                    selectProduct = await _context.Product.FindAsync(product);
                    if (selectProduct is null)
                        return false;

                    _context.Product.Remove(selectProduct);

                    var nChanges = await _context.SaveChangesAsync();

                    if (nChanges == 1)
                        return true;

                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

        public async Task<IEnumerable<dynamic>> GetProducts(int? productId)
        {
            IEnumerable<dynamic> execProcedure;
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@productId", productId, System.Data.DbType.Int32, System.Data.ParameterDirection.Input, null);

            try
            {
                execProcedure = await Get(selectProcedure, dynamicParameters, System.Data.CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return execProcedure;
        }

        internal async Task<IEnumerable<dynamic>> Get(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection db = GetDbConnection())
            {
                return await db.QueryAsync<dynamic>(sp, parms, commandType: commandType);
            };
        }

    }

}
