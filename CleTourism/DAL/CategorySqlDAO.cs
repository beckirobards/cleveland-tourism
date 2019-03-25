using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CleTourism.Models;

namespace CleTourism.DAL
{
    public class CategorySqlDAO : ICategoryDAO
    {
        private string connectionString;
        Category category = new Category();

        /// <summary>
        /// Creates new DAO
        /// </summary>
        /// <param name="connectionString">DAO's connection string</param>
        public CategorySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Category> GetAllCategories()
        {
            IList<Category> categories = new List<Category>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM categories", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Category category = ConvertReaderToCategory(reader);
                        categories.Add(category);
                    }
                }
            }
            catch (SqlException ex)
            {
                // TODO: throw error?
                throw;
            }

            return categories;
        }

        public IList<Category> GetCategory(int id)
        {
            IList<Category> categories = new List<Category>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM categories WHERE id = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        category = ConvertReaderToCategory(reader);
                        categories.Add(category);
                    }
                }
            }
            catch (SqlException ex)
            {
                // TODO: log?
                throw;
            }

            return categories;
        }

        private Category ConvertReaderToCategory(SqlDataReader reader)
        {
            Category category = new Category();
            category.Id = Convert.ToInt32(reader["id"]);
            category.Name = Convert.ToString(reader["name"]);
            return category;
        }
    }
}
