using project_intro.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_intro.Services
{
    public class MockUsersService : IUsersService
    {
        public MockUsersService()
        {

        }
        public Task<bool> IsUserValid(string userName)
        {
            return Task.FromResult(false);
        }
    }
}
