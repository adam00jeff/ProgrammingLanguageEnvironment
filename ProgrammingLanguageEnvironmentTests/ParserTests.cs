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
        /// <summary>
        /// tests the Paraser class
        /// tests the ParseAction method
        /// tests the ParseNumbers method
        /// test the ParseInput method
        /// </summary>
        /// 
        [TestMethod()] // part 2 test
        /// <summary>
        /// tests ParseInput
        /// input correct while loop
        /// </summary>
        public void ParseInputTestVariables()
        {
            //arrange
            var input = "width = 50";
            //calculate
            var result = Parser.ParseInput(input);
            //check
            Assert.IsNotNull(result);
           // Assert.IsInstanceOfType(result, typeof(Command));
            Assert.AreEqual(Action.While, result.Action);
            Assert.IsTrue(result.Paramaters.Contains(10));


        }
        [TestMethod()] // part 2 test
        /// <summary>
        /// tests ParseInput
        /// input correct while loop
        /// </summary>
        public void ParseInputTestBasicWhile()
        {
            //arrange
            var input = "While colour < 10";
            //calculate
            var result = Parser.ParseInput(input);
            //check
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Command));
            Assert.AreEqual(Action.While, result.Action);
            Assert.IsTrue(result.Paramaters.Contains(10));
            //Assert.IsTrue(result.Paramaters.Contains(LESSTHAN));
            //Assert.IsTrue(result.Paramaters.Contains(colour));

        }
        [TestMethod()]// part 2 test
        /// <summary>
        /// tests ParseInput
        /// input correct while loop
        /// </summary>
        public void ParseInputTestBasicIf()
        {
            //arrange
            var input = "If colour < 10";
            //calculate
            var result = Parser.ParseInput(input);
            //check
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Command));
            Assert.AreEqual(Action.If, result.Action);
            Assert.IsTrue(result.Paramaters.Contains(10));
            //Assert.IsTrue(result.Paramaters.Contains(colour));
        }
        public void ParseInputTestBasicColourSwitcher()//part 2 test
        {
            //arrange
            var input = "colour redgreen";
            //calculate
            var result = Parser.ParseInput(input);
            //check
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Command));
            Assert.AreEqual(Action.Colour, result.Action);
            //Assert.IsTrue(result.Paramaters.Contains(redgreen));
        }
        [TestMethod()]
        ///<summary>
        /// tests ParseAction
        /// inputs lowercase string
        /// </summary>
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
        ///<summary>
        /// tests ParseAction
        /// inputs uppercase string
        /// </summary>
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
        ///<summary>
        /// tests ParseAction
        /// inputs string with mixed case
        /// </summary>
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
        ///<summary>
        /// tests ParseAction
        /// inputs multiple strings, one correct
        /// </summary>
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
        ///<summary>
        /// tests ParseAction
        /// inputs two correct strings and only returns the first
        /// </summary>
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
        ///<summary>
        /// tests ParseAction
        /// no correct strings return Action.None
        /// </summary>
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
        ///<summary>
        /// tests ParseAction
        /// empty string returns Action.None
        /// </summary>
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
        ///<summary>
        /// tests ParseNumbers
        /// inputs one string and confirms parsed
        /// </summary>
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
        ///<summary>
        /// tests ParseNumbers
        /// inputs multiple string and confirms parsed
        /// </summary>
        public void ParseNumbersTestMultipleBasicStringInput()
        {
            //arrange
            var input = new List<string> { "50","100","77","45" };
            //calculate
            var result = Parser.ParseNumbers(input);
            //check
            Assert.IsTrue(result.Count() == 4);
            Assert.IsTrue(result.Contains(50));
            Assert.IsTrue(result.Contains(100));
            Assert.IsTrue(result.Contains(77));
            Assert.IsTrue(result.Contains(45));
        }
        [TestMethod()]
        ///<summary>
        /// tests ParseNumbers
        /// inputs multiple string with an incorrect value and confirms parsed
        /// </summary>
        public void ParseNumbersTestMixedBasicStringInput()
        {
            //arrange
            var input = new List<string> { "50", "rabbit", "77", "45" };
            //calculate
            var result = Parser.ParseNumbers(input);
            //check
            Assert.IsTrue(result.Count() == 3);
            Assert.IsTrue(result.Contains(50));
            Assert.IsTrue(result.Contains(77));
            Assert.IsTrue(result.Contains(45));
        }
        [TestMethod()]
        ///<summary>
        /// tests ParseNumbers
        /// inputs incorrect values and confirms parsed out
        /// </summary>
        public void ParseNumbersTestIncorrectBasicStringInput()
        {
            //arrange
            var input = new List<string> { "toast", "rabbit", "shropshire", "planet" };
            //calculate
            var result = Parser.ParseNumbers(input);
            //check
            Assert.IsTrue(result.Count() == 0);
        }

        [TestMethod()]
        /// <summary>
        /// tests ParseInput
        /// input correct string returns action
        /// </summary>
        public void ParseInputTest_returnsCorrectActionCommandtriangle()
        {
            //arrange
            var input = "triangle";
            //calculate
            var result = Parser.ParseInput(input);
            //check
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Command));
            Assert.AreEqual(Action.Triangle, result.Action);
            Assert.IsTrue(!result.Paramaters.Any());
        }
        [TestMethod()]
        /// <summary>
        /// tests ParseInput
        /// input correct string returns action
        /// </summary>
        public void ParseInputTest_returnsCorrectActionCommandsquare()
        {
            //arrange
            var input = "square";
            //calculate
            var result = Parser.ParseInput(input);
            //check
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Command));
            Assert.AreEqual(Action.Square, result.Action);
            Assert.IsTrue(!result.Paramaters.Any());
        }
        [TestMethod()]
        /// <summary>
        /// tests ParseInput
        /// input correct lowercase string and paramater returns action
        /// </summary>
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
        /// <summary>
        /// tests ParseInput
        /// input correct uppercase string returns action
        /// </summary>
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
        /// <summary>
        /// tests ParseInput
        /// input incorrect string returns Action.none and correct params
        /// </summary>
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
        /// <summary>
        /// tests ParseInput
        /// input correct string returns action
        /// the parser allows any combination of paramaters for each action
        /// </summary>
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