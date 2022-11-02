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
        public void ParseInputTest_returnsCorrectActionCommand()
        {
            //arrange
            var input = "circle";

            //calculate
            var result = Parser.ParseInput(input);

            //check
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Command));
            Assert.AreEqual(Action.Circle, result.Action);
            Assert.IsTrue(!result.Paramaters.Any());
        }
               
        [TestMethod()]
        public void ParseNumbersTestBasicStringInput()
        {
            //arrange
            var input = new List<string> { "50" };

            //calculate
            var result = Parser.ParseNumbers(input);

            //check
            Assert.IsTrue(result.Count() == 1);
            Assert.IsTrue(result.Contains(50));
           
            
        }
        [TestMethod()]
        public void ParseInputTestBasicCorrectLowerString()
        {
            //arrange
            var input = "circle 10";

            //calculate
            var result = Parser.ParseInput(input);

            //check
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Command));
            Assert.AreEqual(Action.Circle, result.Action);
            Assert.IsTrue(result.Paramaters.Contains(10));
        }
        [TestMethod()]
        public void ParseInputTestBasicCorrectUpperString()
        {
            //arrange
            var input = "CIRCLE 10";

            //calculate
            var result = Parser.ParseInput(input);

            //check
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Command));
            Assert.AreEqual(Action.Circle, result.Action);
            Assert.IsTrue(result.Paramaters.Contains(10));
        }
        [TestMethod()]
        public void ParseInputTestBacisIncorrectLowerString()
        {
            //arrange
            var input = "cwwircle 10";

            //calculate
            var result = Parser.ParseInput(input);

            //check
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Command));
            Assert.AreEqual(Action.None, result.Action);
            Assert.IsTrue(result.Paramaters.Contains(10));
        }
        [TestMethod()]
        public void ParseInputTestBacisCorrectLowerStringThreeCorrectNumbers()
        {
            //arrange
            var input = "circle 10 30 40";

            //calculate
            var result = Parser.ParseInput(input);

            //check
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Command));
            Assert.AreEqual(Action.Circle, result.Action);
            Assert.IsTrue(result.Paramaters.Contains(10));
            Assert.IsTrue(result.Paramaters.Contains(40));
            Assert.IsTrue(result.Paramaters.Contains(30));
        }
    }
}