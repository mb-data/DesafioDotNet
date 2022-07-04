using Api.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Api.Repositrorios
{
    public class ProdutoRepositorio
    {
        private SqlConnection _con;

        // String de conexão 
        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["stringConexao"].ToString();
            _con = new SqlConnection(constr);
        }

		// Adicionar Produto
		public bool AdicionarProduct(Product productObj)
		{
			Connection();

			int i;

			using (SqlCommand command = new SqlCommand("IncluirProduto", _con))
			{
				command.CommandType = CommandType.StoredProcedure;

				command.Parameters.AddWithValue("@Name", productObj.Name);
				command.Parameters.AddWithValue("@Price", productObj.Price);
				command.Parameters.AddWithValue("@Brand", productObj.Brand);
                command.Parameters.AddWithValue("@CreatedAt", productObj.CreatedAt);

				try
				{
					_con.Open();
					i = command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					_con.Close();
					return false;
				}
			}
			_con.Close();
			return i > 0;
		}

		// Retornar um Produto
		public Product ObterProduto(int id)
		{
			Connection();
			int i;
			Product produto = new Product();

			using (SqlCommand command = new SqlCommand("ObterProdutoPorId", _con))
			{
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@Id", id);
				try
				{
					_con.Open();
					i = command.ExecuteNonQuery();
                }
                catch (Exception ex)
				{
					_con.Close();
					return null;
				}
				if (i > 0)
				{
					return produto;
				}
			}
		}

		// Retornar todos os Produtos
		public List<Product> ObterProductos()
		{
			Connection();

			List<Product> productList = new List<Product>();

			using (SqlCommand command = new SqlCommand("ObterTodosProduto", _con))
			{
				command.CommandType = CommandType.StoredProcedure;
				_con.Open();
				SqlDataReader reader = command.ExecuteReader();

				try
				{
					while (reader.Read())
					{
						Product product = new Product()
						{
							Id = Convert.ToInt32(reader["Id"]),
							Name = Convert.ToString(reader["Name"]),
							Price = Convert.ToDecimal(reader["Price"]),
							Brand = Convert.ToString(reader["Brand"]),
							CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
							UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"]),
						};
						productList.Add(product);
					}
					_con.Close();
					return productList;
				}
				catch (Exception ex)
				{
					_con.Close();
					return new List<Product>();
				}
			}
		}

		// Atualizar Produto
		public bool AtualizarProduct(Product productObj)
		{
			Connection();
			int i;
			using (SqlCommand command = new SqlCommand("AtualizarProdutoPorId", _con))
			{
				command.CommandType = CommandType.StoredProcedure;

				command.Parameters.AddWithValue("@Id", productObj.Id);
				command.Parameters.AddWithValue("@Name", productObj.Name);
				command.Parameters.AddWithValue("@Price", productObj.Price);
				command.Parameters.AddWithValue("@Brand", productObj.Brand);
				command.Parameters.AddWithValue("@UpdatedAt", productObj.UpdatedAt);

				try
				{
					_con.Open();
					i = command.ExecuteNonQuery();

				}
				catch (Exception ex)
				{
					_con.Close();
					return false;
				}
			}
			_con.Close();
			return i > 0;
		}

		// Excluir Produto
		public bool ExcluirProduct(int id)
		{
			Connection();
			int i;
			using (SqlCommand command = new SqlCommand("ExcluirProdutoPorId", _con))
			{
				command.CommandType = CommandType.StoredProcedure;

				command.Parameters.AddWithValue("@Id", id);

				try
				{
					_con.Open();
					i = command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					_con.Close();
					return false;
				}
			}
			if (i >= 1)
			{
				return true;
			}
			return false;
		}

	}
}