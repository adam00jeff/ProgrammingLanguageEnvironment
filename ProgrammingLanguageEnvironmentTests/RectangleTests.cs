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
    public class RectangleTests
    {
        /// <summary>
        /// Tests for the Rectangle Class
        /// </summary>
        [TestMethod()]
        ///<summary>
        /// Tests the Rectangle method
        /// enters paramaters and checks rectangle 
        ///</summary>
        public void RectangleTestCorrectParams()
        {
            //set up test 
            Color colour = Color.Black;
            int x = 5;
            int y = 5;
            int width = 30;
            int height = 30;
            //create a rectangle
            Rectangle r = new Rectangle(colour, x, y, width, height);
            //check results
            Assert.AreEqual(x, r.x);
            Assert.AreEqual(y, r.y);
            Assert.AreEqual(width, r.width);
            Assert.AreEqual(height, r.height);

        }
        [TestMethod()]
        ///<summary>
        /// Tests the Rectangle method
        /// enters unmatched paramaters
        /// </summary>
        public void RectangleTestIncorrectParams()
        {
            //set up test 
            Color colour = Color.Black;
            int x = 3;
            int y = 5;
            int width = 30;
            int height = 30;
            //create a rectangle
            Rectangle r = new Rectangle(colour, x, y, width, height);
            //check results
            Assert.AreNotEqual(5, r.x);
            Assert.AreEqual(y, r.y);
            Assert.AreEqual(width, r.width);
            Assert.AreEqual(height, r.height);
        }
        [TestMethod()]
        ///<summary>
        /// Tests the Rectangle method
        /// enters a maximum variable 
        /// </summary>
        public void RectangleTestmaxwidthvariable()
        {
            //set up test 
            Color colour = Color.Black;
            int x = 2147483647;
            int y = 5;
            int width = 30;
            int height = 30;
            //create a rectangle
            Rectangle r = new Rectangle(colour, x, y, width, height);
            //check results
            Assert.AreEqual(x, r.x);
            Assert.AreEqual(y, r.y);
            Assert.AreEqual(width, r.width);
            Assert.AreEqual(height, r.height);
        }
        [TestMethod()]
        ///<summary>
        /// Tests the Rectangle method
        /// enters a maximum variable 
        /// </summary>
        public void RectangleTestmaxheighthvariable()
        {
            //set up test 
            Color colour = Color.Black;
            int x = 5;
            int y = 5;
            int width = 30;
            int height = 2147483647;
            //create a rectangle
            Rectangle r = new Rectangle(colour, x, y, width, height);
            //check results
            Assert.AreEqual(x, r.x);
            Assert.AreEqual(y, r.y);
            Assert.AreEqual(width, r.width);
            Assert.AreEqual(height, r.height);
        }
        [TestMethod()]
        ///<summary>
        /// Tests the Rectangle drawing a square
        /// enters a maximum variable 
        /// </summary>
        public void SquareTest()
        {
            //set up test 
            Color colour = Color.Black;
            int x = 5;
            int y = 5;
            int width = 30;
            int height = 30;
            //create a rectangle
            Rectangle r = new Rectangle(colour, x, y, width, height);
            //check results
            Assert.AreEqual(x, r.x);
            Assert.AreEqual(y, r.y);
            Assert.AreEqual(width, r.width);
            Assert.AreEqual(height, r.height);
        }

    }
}