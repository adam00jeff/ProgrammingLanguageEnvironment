using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{
    /// <summary>
    /// class to hold parser methods for processing user input
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// parses string tokens and returns the first that matches to an Action in the ENUMS 
        /// </summary>
        /// <param name="tokens">the string tokens from input</param>
        /// <returns>an instance of the Action Enums if matched,Action.none if unmatched</returns>
        public static Action ParseAction(IEnumerable<string> tokens)
        {
            var actions = Enum.GetNames(typeof(Action)); // creates a list of actions
            var firstAction = tokens.Select(ToTitleCase).FirstOrDefault(token => actions.Contains(token));//selects the first entry that matches an action from the input and passes to title case
            return string.IsNullOrEmpty(firstAction) ? Action.None : (Action)Enum.Parse(typeof(Action), firstAction);//checks the action is not null (Action.none is sent for null) if not empty returns an Action
        }
        /// <summary>
        /// returns a string in TitleCase
        /// Culture info is used to check application 
        /// </summary>
        /// <param name="input">the string to be parsed</param>
        /// <returns>the input string in Title Case</returns>
        private static string ToTitleCase(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());//corrects Title Case for region
        }
        /// <summary>
        /// parses an input of strings into integers for use in shape paramaters
        /// </summary>
        /// <param name="tokens">the seperated strings of input</param>
        /// <returns>a list of itegers from the input strings</returns>
        public static IEnumerable<int> ParseNumbers(IEnumerable<string> tokens)
        {
            Regex nonDigits = new Regex(@"[^\d]");// sets a mask for removing things than arent an int
            List<string> input = (List<string>)tokens; // saves the input strings to a list

            List<string> intlist = input.Select(l => nonDigits.Replace(l, "")).ToList();// creates a list with all non-digits of input removed
            IEnumerable<int> checkedlist = intlist.Select// check values are all integers
                (s => Int32.TryParse(s, out int n) ? n : (int?)null) 
                .Where(n => n.HasValue) // select integers with values
                 .Select(n => n.Value) // select the values of those ints
                .ToList(); // saves them in the checked list
           return checkedlist;
        }
        /// <summary>
        /// calls both parse methods on the user input
        /// parses and splits input
        /// removes whitespace
        /// </summary>
        /// <param name="input">a user input string</param>
        /// <returns>a command to performed with action and pramaters</returns>
        /// <exception cref="NotImplementedException">catched null inputs</exception>
        public static Command ParseInput(string input)
            {
            var line = input.ToLower();//passes input to lower case
            var trim = line.Trim();//removes whitespace
                if (input == null)//checks the input has value
                {
                    throw new ArgumentNullException(nameof(input));
                }
                IEnumerable<string> tokens = trim.Split(' ', ',').ToList(); //creates a string of tokens from the input
                var action = ParseAction(tokens);//finds the action from the input
                var numbers = ParseNumbers(tokens);//finds the paramaters from the input
                return new Command(action, numbers);//creates a command from the action+paramaters 
            
            }
        }
    } 
