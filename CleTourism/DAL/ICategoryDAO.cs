using CleTourism.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleTourism.DAL
{
    public interface ICategoryDAO
    {
        /// <summary>
        /// Returns a list of all neighborhoods in the database
        /// </summary>
        /// <returns></returns>
        IList<Category> GetAllCategories();

        /// <summary>
        /// Based on a given category ID, returns the activity's categories
        /// </summary>
        /// <returns></returns>
        IList<Category> GetCategory(int id);
    }
}
