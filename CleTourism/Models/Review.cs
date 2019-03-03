using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleTourism.Models
{
    public class Review
    {
        /// <summary>
        /// Review's id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First name of reviewer
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of reviewer
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Id of activity being reviewed
        /// </summary>
        public int ActivityId { get; set; }

        /// <summary>
        /// Rating given to the reviewed activity (scale of 1-5)
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Written review about the activity (optional)
        /// </summary>
        public string FullReview { get; set; }
    }
}
