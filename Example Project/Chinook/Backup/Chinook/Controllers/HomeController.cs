using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Chinook.Domain;
using Chinook.Persistence.Interfaces;

namespace Chinook.Controllers
{
    public class HomeController : Controller
    {
        private ITrackDao trackDao = null;

        public HomeController(ITrackDao trackDao)
        {
            this.trackDao = trackDao;
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {
            DbResult<Track> results = trackDao.FindAll();

            return View(results);
        }

    }
}
