using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{
    public class Parser
    {
        /// <summary>
        /// parses string tokens and returns the first that confirms to an Action in the ENUMS 
        /// </summary>
        /// <param name="tokens">the string tokens from input</param>
        /// <returns>an instance of the Action Enums if matched,Action.none if unmatched</returns>
       public static Action ParseAction(IEnumerable<string> tokens)
        {
            var actions = Enum.GetNames(typeof(Action));
            var firstAction = tokens.Select(ToTitleCase).FirstOrDefault(token => actions.Contains(token));
            return string.IsNullOrEmpty(firstAction) ? Action.None : (Action)Enum.Parse(typeof(Action), firstAction);
        }
        /// <summary>
        /// returns a string in lower case 
        /// 
        /// TO DO -> SHOULD TRIM?
        /// 
        /// 
        /// </summary>
        /// <param name="input">the string to be lowered</param>
        /// <returns></returns>
        private static string ToTitleCase(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }
        /// <summary>
        ///parses int tokens and returns them 
        ///
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static IEnumerable<int> ParseNumbers(IEnumerable<string> tokens)
        {
            IEnumerable<int> result = tokens.Select(int.Parse);
            
            return result;


            
        }
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static Command ParseInput(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            IEnumerable<string> tokens = input.Split(' ').ToList();
            var action = ParseAction(tokens);
            var numbers = ParseNumbers(tokens);
            return new Command(action, numbers);
        }
    }
}
