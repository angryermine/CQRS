using System.Web.Mvc;
using Application.Common.Commands;
using Application.Common.Queries;
using Application.Queries.AccountQueries;

namespace Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public HomeController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        public ActionResult Index()
        {
            var vm = new HomeIndexViewModel()
            {
                Total = _queryDispatcher.Ask(new AccountTotalCountQuery())
            };

            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    public class HomeIndexViewModel
    {
        public int Total { get; set; }
    }
}