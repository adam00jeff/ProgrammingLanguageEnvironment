using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgrammingLanguageEnvironment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment.Tests
{
    [TestClass()]
    public class ParserTests
    {
        [TestMethod()]
        public void ParseAction_withOneStringLowerCase_returnsCorrectAction()
        {
            var input = new List<string> { "circle" };

            var result = Parser.ParseAction(input);

            Assert.AreEqual(Action.Circle,result);
        }
    }
}