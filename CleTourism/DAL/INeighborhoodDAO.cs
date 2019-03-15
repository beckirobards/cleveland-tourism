using CleTourism.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleTourism.DAL
{
    public interface INeighborhoodDAO
    {
        /// <summary>
        /// Returns all neighborhoods
        /// </summary>
        /// <returns></returns>
        Neighborhood GetNeighborhood(int id);
    }
}
