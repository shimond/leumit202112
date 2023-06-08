using project_intro.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_intro.Services
{
    public class ShimonUsersService : IUsersService
    {
        private readonly INotifier _notifier;

        public ShimonUsersService(INotifier notifier)
        {
            _notifier = notifier;
        }
        public Task<bool> IsUserValid(string userName)
        {
            return Task.FromResult(true);
        }
    }
}
