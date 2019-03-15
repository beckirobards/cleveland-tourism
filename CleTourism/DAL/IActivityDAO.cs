using CleTourism.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleTourism.DAL
{
    public interface IActivityDAO
    {
        /// <summary>
        /// Returns all activities
        /// </summary>
        /// <returns></returns>
        IList<Activity> GetAllActivities();

        /// <summary>
        /// Returns all details about a specific activity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Activity GetActivityDetails(int id);
    }
}
