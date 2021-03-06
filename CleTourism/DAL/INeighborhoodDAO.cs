﻿using CleTourism.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleTourism.DAL
{
    public interface INeighborhoodDAO
    {
        /// <summary>
        /// Returns a list of all neighborhoods in the database
        /// </summary>
        /// <returns></returns>
        IList<Neighborhood> GetAllNeighborhoods();

        /// <summary>
        /// Based on a given activity ID, returns the activity's neighborhood
        /// </summary>
        /// <returns></returns>
        Neighborhood GetNeighborhood(int id);
    }
}
