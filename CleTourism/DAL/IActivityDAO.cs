using CleTourism.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleTourism.DAL
{
    interface IActivityDAO
    {
        /// <summary>
        /// Returns all activities
        /// </summary>
        /// <returns></returns>
        IList<Activity> GetAllActivities();
    }
}
