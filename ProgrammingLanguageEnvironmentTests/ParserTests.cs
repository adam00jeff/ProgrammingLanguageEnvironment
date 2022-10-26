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
            //arrange
            var input = new List<string> { "circle" };

            //calculate
            var result = Parser.ParseAction(input);

            //check
            Assert.AreEqual(Action.Circle, result);
        }
        [TestMethod()]
        public void ParseAction_withOneStringUpperCase_returnsCorrectAction()
        {
            //arrange
            var input = new List<string> { "CIRCLE" };

            //calculate
            var result = Parser.ParseAction(input);

            //check
            Assert.AreEqual(Action.Circle, result);
        }
        [TestMethod()]
        public void ParseAction_withOneStringMultiCase_returnsCorrectAction()
        {
            //arrange
            var input = new List<string> { "cIrClE" };

            //calculate
            var result = Parser.ParseAction(input);

            //check
            Assert.AreEqual(Action.Circle, result);
        }
        [TestMethod()]
        public void ParseAction_withOneCorrectStringTwoIncorrectString_returnsCorrectAction()
        {
            //arange
            var input = new List<string> { "circle", "pillow", "mexico" };

            //calculate
            var result = Parser.ParseAction(input);

            //check
            Assert.AreEqual(Action.Circle, result);
        }
        [TestMethod()]
        public void ParseAction_withTwoCorrectString_returnsonlyfirstCorrectAction()
        {
            //arrange
            var input = new List<string> { "circle", "square" };

            //calculate
            var result = Parser.ParseAction(input);

            //check
            Assert.AreEqual(Action.Circle, result);
        }
        [TestMethod()]
        public void ParseAction_withNoCorrectString_returnsNoneAction()
        {
            //arrange
            var input = new List<string> { "envy", "pillow", "mexico" };

            //calculate
            var result = Parser.ParseAction(input);

            //check
            Assert.AreEqual(Action.None, result);
        }
        [TestMethod()]
        public void ParseAction_withNoString_returnsNoneAction()
        {
            //arrange
            var input = new List<string> { "" };

            //calculate
            var result = Parser.ParseAction(input);

            //check
            Assert.AreEqual(Action.None, result);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "exception not thrown")]
        public void ParseAction_withNullString_returnsCorrectException()
        {
            //exception expected 
            //passes null to parser
            Parser.ParseAction(null);

        }

        [TestMethod()]
        public void ParseNumbersTest_returnsCorrectNumbers()
        {
            //arrange
            var input = new List<string> { "50" };

            //calculate
            var result = Parser.ParseNumbers(input);

            //check
            Assert.AreEqual("50", result);
        }

        [TestMethod()]
        public void ParseInputTest()
        {
            Assert.Fail();
        }
    }
}