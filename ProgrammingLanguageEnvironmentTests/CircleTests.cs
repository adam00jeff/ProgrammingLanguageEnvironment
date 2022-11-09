using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgrammingLanguageEnvironment;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment.Tests
{
   
    [TestClass()]
    public class CircleTests
    {
    /// <summary>
    /// Tests the Circle class
    /// </summary>
        [TestMethod()]
        /// <summary>
        /// Tests the circle method
        /// draws a circle
        /// </summary>
        public void CircleTestCorrectParamaters()
        {
            //set up test 
            Color colour = Color.Black;
            int x = 5;
            int y = 5;
            int radius = 100;
            //create a rectangle
            Circle c = new Circle(colour, x, y, radius);
            //check results
            Assert.AreEqual(x, c.x);
            Assert.AreEqual(y, c.y);
            Assert.AreEqual(radius, c.radius);
        }
        [TestMethod()]
        /// <summary>
        /// Tests the circle method
        /// draws a circle with maximum radius
        /// </summary>
        public void CircleTest()
        {
            //set up test 
            Color colour = Color.Black;
            int x = 5;
            int y = 5;
            int radius = 2147483647;
            //create a rectangle
            Circle c = new Circle(colour, x, y, radius);
            //check results
            Assert.AreEqual(x, c.x);
            Assert.AreEqual(y, c.y);
            Assert.AreEqual(radius, c.radius);
        }
        [TestMethod()]
        /// <summary>
        /// Tests the circle method
        /// draws a circle with unmatched paramaters
        /// </summary>
        public void CircleTestIncorrectParams()
        {
            //set up test 
            Color colour = Color.Black;
            int x = 3;
            int y = 5;
            int radius = 100;
            //create a Circle
            Circle c = new Circle(colour, x, y, radius);
            //check results
            Assert.AreNotEqual(5, c.x);
            Assert.AreEqual(y, c.y);
            Assert.AreEqual(radius, c.radius);
        }

    }
}