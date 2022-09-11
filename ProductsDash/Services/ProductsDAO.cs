using FirstWebAppMVC.Models;
using System.Data.SqlClient;

namespace FirstWebAppMVC.Services
{
    // Sample data generated with Mockeroo
    public class ProductsDAO : IProductDataService
    {
        string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> list = new List<ProductModel>();

            string sql = "SELECT TOP 50 * FROM dbo.Products";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        list.Add(new ProductModel
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Price = (decimal)reader[2],
                            Description = (string)reader[3]
                        });
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return list;
        }

        public ProductModel GetProductById(int id)
        {
            string sql = "SELECT * FROM dbo.Products WHERE Id = @Id";
            ProductModel product = new ProductModel();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                try
                {
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        product = new ProductModel
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Price = (decimal)reader[2],
                            Description = (string)reader[3]
                        };
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return product;
        }

        public int Insert(ProductModel product)
        {
            string sql = "INSERT INTO dbo.Products (Name, Price, Description) " +
                "VALUES (@Name, @Price, @Description); " +
                "SELECT CAST(scope_identity() AS int)";

            int newId = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Description", product.Description);

                try
                {
                    connection.Open();
                    newId = (int)cmd.ExecuteScalar();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    newId = -1;
                }
            }

            product.Id = newId;
            return newId;
        }

        public List<ProductModel> Search(string query)
        {
            List<ProductModel> list = new List<ProductModel>();

            string sql = "SELECT * FROM dbo.Products WHERE Name LIKE @Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Name", '%' + query + '%');
                try
                {
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new ProductModel
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Price = (decimal)reader[2],
                            Description = (string)reader[3]
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return list;
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
