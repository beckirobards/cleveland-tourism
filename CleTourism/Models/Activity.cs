using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleTourism.Models
{
    public class Activity
    {
        /// <summary>
        /// Activity's id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Activity's customer-facing name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Activity's neighborhood's id
        /// </summary>
        public int NeighborhoodId { get; set; }

        /// <summary>
        /// Activity's address (without street name)
        /// </summary>
        public int AddressNumber { get; set; }

        /// <summary>
        /// Activity's street name
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Activity's additional address details, e.g. suite number
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// Activity's city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Activity's state
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Activity's zip code
        /// </summary>
        public string ZipCode { get; set; }
        
        /// <summary>
        /// Activity's related website
        /// </summary>
        public string Website { get; set; }

        /// <summary>
        /// Activity's contact phone number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Activity's price range (scale of 1-4)
        /// </summary>
        public int PriceRange { get; set; }

        /// <summary>
        /// Activity's description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Average length of time required for the activity
        /// </summary>
        public int AvgLength { get; set; }

        /// <summary>
        /// Average rating given to activity by users (scale of 1-5)
        /// </summary>
        public int AvgRating { get; set; }

        /// <summary>
        /// Number of ratings submitted by users for the activity
        /// </summary>
        public int RatingCount { get; set; }

        /// <summary>
        /// Activity's image
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Name of neighborhood where activity takes place
        /// </summary>
        public string NeighborhoodName { get; set; }

        /// <summary>
        /// List of categories applied to the activity
        /// </summary>
        public List<string> CategoryNames { get; set; }

    }
}
