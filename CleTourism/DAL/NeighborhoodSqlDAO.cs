﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CleTourism.Models;

namespace CleTourism.DAL
{
    public class NeighborhoodSqlDAO : INeighborhoodDAO
    {
        private string connectionString;
        Neighborhood neighborhood = new Neighborhood();

        /// <summary>
        /// Creates new DAO
        /// </summary>
        /// <param name="connectionString">DAO's connection string</param>
        public NeighborhoodSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Neighborhood> GetAllNeighborhoods()
        {
            IList<Neighborhood> neighborhoods = new List<Neighborhood>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM neighborhoods", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Neighborhood neighborhood = ConvertReaderToNeighborhood(reader);
                        neighborhoods.Add(neighborhood);
                    }
                }
            }
            catch (SqlException ex)
            {
                // TODO: throw error?
                throw;
            }

            return neighborhoods;
        }

        public Neighborhood GetNeighborhood(int id)
        {
            Neighborhood neighborhood = new Neighborhood();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM neighborhoods WHERE id = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        neighborhood = ConvertReaderToNeighborhood(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                // TODO: log?
                throw;
            }

            return neighborhood;
        }

        private Neighborhood ConvertReaderToNeighborhood(SqlDataReader reader)
        {
            Neighborhood neighborhood = new Neighborhood();
            neighborhood.Id = Convert.ToInt32(reader["id"]);
            neighborhood.Name = Convert.ToString(reader["name"]);

            return neighborhood;
        }
    }
}
