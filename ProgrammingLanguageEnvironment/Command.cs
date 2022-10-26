using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{
    public class Command
    {
        internal Action Action { get; set; }
        internal IEnumerable<int> Coordinates { get; set; }

        public Command(Action action, IEnumerable<int> coordinates)
        {
            Action = action;
            Coordinates = coordinates;
        }
    }
}
