using project_intro.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_intro.Services
{
    public class ConsoleNotifier : INotifier
    {
        public ConsoleNotifier()
        {

        }
        public Task Notify(string message)
        {
            Console.WriteLine(message);
            return Task.CompletedTask;
        }


    }
}
