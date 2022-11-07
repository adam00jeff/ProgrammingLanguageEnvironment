using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{

    public class Command
    {/// <summary>
    /// Commad class allows creation of commands
    /// 
    /// </summary>
        public Action Action { get; set; }
        public IEnumerable<int> Paramaters { get; set; }
        /// <summary>
        /// Commands hold the action to be performed and the associated paramaters
        /// input is parsed into commands
        /// </summary>
        /// <param name="action">The action parsed from input</param>
        /// <param name="paramaters">The paramaters for the action</param>
        public Command(Action action, IEnumerable<int> paramaters)
        {
            Action = action;
            Paramaters= paramaters;
        }

     }


}
