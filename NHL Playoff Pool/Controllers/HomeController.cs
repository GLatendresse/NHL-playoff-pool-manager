using NHL_Playoff_Pool.Engines.DataRetriever;
using NHL_Playoff_Pool.Models.Context;
using System.Linq;
using System.Web.Mvc;
using static NHL_Playoff_Pool.Enumerators.EnumeratorsAndConstants;

namespace NHL_Playoff_Pool.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            //return View();
            //var nhlTeamsParser = new NHLTeamsParser();
            //nhlTeamsParser.PopulateNHLTeams();

            var dbContext = new PoolManagerDbContext();

            var trouvaille = dbContext.NHLTeams.First(nt => nt.PlayoffSpot == PlayoffSpots.EWC2);

            return View("PoolManager");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}