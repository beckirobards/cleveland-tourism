using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleTourism.DAL;
using CleTourism.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleTourism.Controllers
{
    public class ActivityController : Controller
    {
        private IActivityDAO activityDao;
        private INeighborhoodDAO neighborhoodDao;
        // TODO: add new ICategoryDAO
        //private ICategoryDAO categoryDao;
        public ActivityController(IActivityDAO activityDao, INeighborhoodDAO neighborhoodDao)
        {
            this.activityDao = activityDao;
            this.neighborhoodDao = neighborhoodDao;
        }

        public IActionResult Index()
        {
            IList<Activity> activities = activityDao.GetAllActivities();
            foreach (Activity activity in activities)
            {
                activity.NeighborhoodName = neighborhoodDao.GetNeighborhood(activity.Id).Name;
                //activity.CategoryNames = categoryDao.GetCategory(activity.Id)
            }
            return View(activities);
        }

        public IActionResult ActivityDetails(int id)
        {
            Activity activity = activityDao.GetActivityDetails(id);
            activity.NeighborhoodName = neighborhoodDao.GetNeighborhood(id).Name;

            return View(activity);
        }

        [HttpGet]
        public IActionResult Search()
        {
            IList<Neighborhood> neighborhoods = neighborhoodDao.GetAllNeighborhoods();
            ViewData["neighborhoods"] = neighborhoods;

            return View();
        }

        [HttpGet]
        public IActionResult SearchResult(ActivitySearch searchModel)
        {
            IList<Activity> activities = activityDao.GetAllActivities(searchModel.Neighborhood);

            searchModel.ActivityResults = activities;

            return View(searchModel);
        }

    }
}