using ApiDotNetCore.Config;
using ApiDotNetCore.Entities;
using ApiDotNetCore.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace ApiDotNetCore.Repositories
{
    public class SqlServerRepository : IRepository<ProductEntity, int>
    {
        protected string stringConnection;
        public SqlServerRepository()
        {
            stringConnection = Configuration.ConnectionString;
        }

        public List<ProductEntity> GetAll()
        {
            using (var conn = new SqlConnection(stringConnection))
            {
                List<ProductEntity> listaProdutos = new List<ProductEntity>();
                ProductEntity produto = null;
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_select_products", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            produto = new ProductEntity()
                            {
                                CreatedAt = (DateTime)reader["createdAt"],
                                Name = reader["name"].ToString(),
                                Price = (double)reader["price"],
                                Brand = reader["brand"].ToString(),
                                UpdatedAt = (DateTime?)reader["updatedAt"],
                                Id = (int)reader["id"],
                            };
                            listaProdutos.Add(produto);
                        }
                    }
                }
                catch (Exception error)
                {
                    throw error;
                }
                return listaProdutos;
            }
        }

        public ProductEntity GetById(int id)
        {
            using (var conn = new SqlConnection(stringConnection))
            {
                ProductEntity produto = null;
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_select_products", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            produto = new ProductEntity()
                            {
                                CreatedAt = (DateTime)reader["createdAt"],
                                Name = reader["name"].ToString(),
                                Price = (double)reader["price"],
                                Brand = reader["brand"].ToString(),
                                UpdatedAt = (DateTime?)reader["updatedAt"],
                                Id = (int)reader["id"],
                            };
                        }
                    }
                }
                catch (Exception error)
                {
                    throw error;
                }
                return produto;
            }
        }

        public int Insert(ProductEntity entity)
        {
            using (var conn = new SqlConnection(stringConnection))
            {
                try
                {
                    var cmd = new SqlCommand("sp_insert_products", conn);
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", entity.Name);
                    cmd.Parameters.AddWithValue("@brand", entity.Brand);
                    cmd.Parameters.AddWithValue("@price", entity.Price);

                    SqlParameter id = new SqlParameter();
                    id.ParameterName = "@id";
                    id.Direction = ParameterDirection.Output;
                    id.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(id);

                    cmd.ExecuteNonQuery();

                    return (int)id.Value;
                }
                catch (Exception error)
                {

                    throw error;
                }

            }
        }

        public void Update(ProductEntity entity, int id)
        {
            using (var conn = new SqlConnection(stringConnection))
            {
                try
                {
                    var cmd = new SqlCommand("sp_update_products", conn);
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", entity.Name);
                    cmd.Parameters.AddWithValue("@brand", entity.Brand);
                    cmd.Parameters.AddWithValue("@price", entity.Price);
                    cmd.ExecuteNonQuery();

                }
                catch (Exception error)
                {
                    throw error;
                }

            }
        }

        public void Delete(int id)
        {
            using (var conn = new SqlConnection(stringConnection))
            {
                try
                {
                    var cmd = new SqlCommand("sp_delete_products", conn);
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    throw error;
                }

            }
        }

    }
}
