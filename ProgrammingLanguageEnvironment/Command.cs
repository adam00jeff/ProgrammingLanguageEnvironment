using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{
    public class Command
    {
        public Action Action { get; set; }
        public IEnumerable<int> Paramaters { get; set; }

        public Command(Action action, IEnumerable<int> paramaters)
        {
            Action = action;
            Paramaters= paramaters;
        }

     }


}
