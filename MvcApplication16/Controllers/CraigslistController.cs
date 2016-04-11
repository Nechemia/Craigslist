using MvcApplication16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication16.Controllers
{
    public class CraigslistController : Controller
    {
        //
        // GET: /Craigslist/

        public ActionResult Index()
        {
            Manager M = new Manager();
            var allAds = M.GetAllAds();
            //IEnumerable<PersonProductItem> allUniqueAds = allAds.Select(x => x.PersonProductId).Distinct();
            return View(allAds);
        }
        public ActionResult Freebie(int Id)
        {
            Manager M = new Manager();
            var Ad = M.GetAd(Id);
            return View(Ad);
        }
        public ActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddItem(HttpPostedFileBase[]Image, PersonProduct PP)
        {
            Manager M = new Manager();
            
            string [] fileNames = new string[Image.Length];
            for (int i = 0; i < 5; i++ )
            {
                Guid g = Guid.NewGuid();
                Image[i].SaveAs(Server.MapPath("~/Uploads/" + g + ".jpg"));
                fileNames[i] = g.ToString() + ".jpg";
            }
            M.AddPersonPoduct(PP, fileNames);
            
            //M.AddPersonPoduct(PP, g.ToString() + ".jpg");
            return View();
        }


    }
}
