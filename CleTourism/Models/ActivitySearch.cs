using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleTourism.Models
{
    public class ActivitySearch
    {
        /// <summary>
        /// The neighborhood name to search for
        /// </summary>
        public string Neighborhood { get; set; }

        // TODO: Complete category search
        /// <summary>
        /// The category name to search for
        /// </summary>
        //public string Category { get; set; }

        /// <summary>
        /// List of activities that match user's search terms
        /// </summary>
        public IList<Activity> ActivityResults { get; set; }
    }
}
