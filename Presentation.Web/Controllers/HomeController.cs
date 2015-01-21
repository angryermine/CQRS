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
        private static readonly Random _random = new Random();

        public HomeController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        public ActionResult Index(int page = 1)
        {
            var totalAccounts = _queryDispatcher.Ask(new AccountTotalCountQuery());

            if (totalAccounts == 0)
            {
                for (var i = 1; i <= 10; i++)
                {
                    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

                    var email = string.Format("user_{0}@example.com", i);
                    var password = new string(Enumerable.Repeat(chars, 8).Select(s => s[_random.Next(s.Length)]).ToArray());

                    _commandDispatcher.Send(new CreateAccountCommand(email, password));
                }

                totalAccounts = _queryDispatcher.Ask(new AccountTotalCountQuery());
            }

            var vm = new HomeIndexViewModel
            {
                Total = totalAccounts,
                Accounts =  _queryDispatcher.Ask(new AccountsPagedQuery(page, 10))
            };

            return View(vm);
        }
    }
}