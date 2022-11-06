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
    public class Parser
    {
        /// <summary>
        /// parses string tokens and returns the first that confirms to an Action in the ENUMS 
        /// </summary>
        /// <param name="tokens">the string tokens from input</param>
        /// <returns>an instance of the Action Enums if matched,Action.none if unmatched</returns>
        public static Action ParseAction(IEnumerable<string> tokens)
        {
           // var listinput = new List<string>(tokens);
           // var listactions = new List<string>(Enum.GetNames(typeof(Action)));
           // var result = listinput.Where(a => listactions.Any(act => act.Contains(a)));
           //var res2 = result.ToList();
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
            
            List<int> result = new List<int>();
            //  IEnumerable<int> list3 = new List<int>();             // sets up an enum to store result
            Regex nonDigits = new Regex(@"[^\d]");           // sets a regex for removing things than arent an int

            List<string> input = (List<string>)tokens;
           // List<string> split = input.Split(',');

            List<string> list2 = input.Select(l => nonDigits.Replace(l, "")).ToList();         // iterates through a list of tokens, removing things that are not ints
            IEnumerable<int> list3 = list2.Select(s => Int32.TryParse(s, out int n) ? n : (int?)null)            // parses the list2 checking for nulls
                .Where(n => n.HasValue)
                 .Select(n => n.Value)
                .ToList(); // saves in list 3


            foreach (var i in list3)
            {
                result.Add(i);
            }

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

            var line = input.ToLower();
            var trim = line.Trim();
            
                if (input == null)
                {
                    throw new ArgumentNullException(nameof(input));
                }
                

                IEnumerable<string> tokens = trim.Split(' ',',').ToList();
                var action = ParseAction(tokens);
                
                var numbers = ParseNumbers(tokens);
                return new Command(action, numbers);
            }
        }
    } 
