using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CleTourism.Models;

namespace CleTourism.DAL
{
    public class ActivitySqlDAO : IActivityDAO
    {
        private string connectionString;

        /// <summary>
        /// Creates new DAO
        /// </summary>
        /// <param name="connectionString">DAO's connection string</param>
        public ActivitySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Gets all activities from a sql database
        /// </summary>
        /// <returns></returns>
        public IList<Activity> GetAllActivities()
        {
            List<Activity> activities = new List<Activity>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM activities", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Activity activity = ConvertReaderToActivity(reader);
                        activities.Add(activity);
                    }
                }
            }
            catch (SqlException ex)
            {
                // TODO: log?
                throw;
            }

            return activities;
        }

        public Activity GetActivityDetails(int id)
        {
            Activity activity = new Activity();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM activities WHERE id = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        activity = ConvertReaderToActivity(reader);
                    }

                }
            }
            catch (SqlException ex)
            {

                throw;
            }

            return activity;
        }

        private Activity ConvertReaderToActivity(SqlDataReader reader)
        {
            Activity activity = new Activity();

            // TODO: change open/close datatypes in SQL & here?
            activity.Id = Convert.ToInt32(reader["id"]);
            activity.Name = Convert.ToString(reader["name"]);
            activity.NeighborhoodId = Convert.ToInt32(reader["neighborhood_id"]);
            activity.AddressNumber = Convert.ToInt32(reader["address_number"]);
            activity.StreetName = Convert.ToString(reader["street_name"]);
            activity.Address2 = Convert.ToString(reader["address2"]);
            activity.City = Convert.ToString(reader["city"]);
            activity.State = Convert.ToString(reader["state"]);
            activity.ZipCode = Convert.ToString(reader["zip_code"]);
            activity.Website = Convert.ToString(reader["website"]);
            activity.Phone = Convert.ToString(reader["phone"]);
            activity.PriceRange = Convert.ToInt32(reader["price_range"]);
            activity.Description = Convert.ToString(reader["description"]);
            activity.AvgLength = Convert.ToInt32(reader["avg_length"]);
            activity.AvgRating = Convert.ToInt32(reader["avg_rating"]);
            activity.RatingCount = Convert.ToInt32(reader["rating_count"]);
            activity.Image = Convert.ToString(reader["image"]);
            // TODO: maybe re-add daily times
            //activity.SunOpen = Convert.ToDateTime(reader["sun_open"]);
            //activity.SunClose = Convert.ToDateTime(reader["sun_close"]);
            //activity.MonOpen = Convert.ToDateTime(reader["mon_open"]);
            //activity.MonClose = Convert.ToDateTime(reader["mon_close"]);
            //activity.TuesOpen = Convert.ToDateTime(reader["tues_open"]);
            //activity.TuesClose = Convert.ToDateTime(reader["tues_close"]);
            //activity.WedOpen = Convert.ToDateTime(reader["wed_open"]);
            //activity.WedClose = Convert.ToDateTime(reader["wed_close"]);
            //activity.ThursOpen = Convert.ToDateTime(reader["thurs_open"]);
            //activity.ThursClose = Convert.ToDateTime(reader["thurs_close"]);
            //activity.FriOpen = Convert.ToDateTime(reader["fri_open"]);
            //activity.FriClose = Convert.ToDateTime(reader["fri_close"]);
            //activity.SatOpen = Convert.ToDateTime(reader["sat_open"]);
            //activity.SatClose = Convert.ToDateTime(reader["sat_close"]);

            return activity;
        }
    }
}
