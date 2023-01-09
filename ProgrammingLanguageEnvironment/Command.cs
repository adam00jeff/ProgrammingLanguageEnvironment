using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{
    /// <summary>
    /// Commad class allows creation of commands
    /// commands are passed from parser classes to execute class to draw to shapes array
    /// </summary>
    public class Command
    {
        /// <summary>Gets or sets the action.</summary>
        /// <value>The requested action from Action Class</value>
        public Action Action { get; set; }
        /// <summary>Gets or sets the paramaters for a given action</summary>
        /// <value>The paramaters input for the action</value>
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
