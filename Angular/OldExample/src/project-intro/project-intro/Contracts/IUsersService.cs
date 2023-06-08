using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_intro.Contracts
{
    public interface IUsersService
    {
        Task<bool> IsUserValid(string userName);
    }
}
