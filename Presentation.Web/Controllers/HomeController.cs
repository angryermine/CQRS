using System;
using System.Linq;
using System.Web.Mvc;
using Application.Commands.AccountCommands;
using Application.Common.Commands;
using Application.Common.Queries;
using Application.Queries.AccountQueries;
using Presentation.Web.Models;

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

        public ActionResult Index(int page = 1)
        {
            var totalAccounts = _queryDispatcher.Ask(new AccountTotalCountQuery());
            var todayAccounts = _queryDispatcher.Ask(new AccountTodayCountQuery());
            var monthAccounts = _queryDispatcher.Ask(new AccountMonthCountQuery());

            var vm = new HomeIndexViewModel
            {
                Total = totalAccounts,
                Today = todayAccounts,
                Month = monthAccounts,
                Accounts =  _queryDispatcher.Ask(new AccountsPagedQuery(page, 20))
            };

            return View(vm);
        }

        public ActionResult Account(int id)
        {
            var account = _queryDispatcher.Ask(new AccountByIdQuery(id));

            var vm = new HomeAccountViewModel
            {
                Id = account.Id,
                Name = account.Name,
                Email = account.Email,
                RegistrationDate = account.RegistrationDate
            };
            
            return View(vm);
        }
    }
}