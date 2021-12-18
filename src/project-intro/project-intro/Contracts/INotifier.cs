using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_intro.Contracts
{
    public interface INotifier
    {
        Task Notify(string message);
    }
}
