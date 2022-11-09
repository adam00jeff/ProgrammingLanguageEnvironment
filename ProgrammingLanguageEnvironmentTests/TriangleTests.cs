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
    public class TriangleTests
    {
        /// <summary>
        /// Tests for the Triangle Class
        /// </summary>
        [TestMethod()]
        ///<summary>
        /// Tests the Triangle method
        /// enters paramaters and checks Triangle 
        ///</summary>
        public void TriangleTestCorrectParams()
        {
            //set up test 
            Color colour = Color.Black;
            int x = 5;
            int y = 5;
            int side1 = 30;
            int side2 = 30;
            int side3 = 30;
            //create a rectangle
            Triangle t = new Triangle(colour, x, y, side1, side2, side3);
            //check results
            Assert.AreEqual(x, t.x);
            Assert.AreEqual(y, t.y);
            Assert.AreEqual(side1, t.side1);
            Assert.AreEqual(side2, t.side2);
            Assert.AreEqual(side3, t.side3);
        }
        [TestMethod()]
        ///<summary>
        /// Tests the Triangle method
        /// enters incorrect paramaters and checks Triangle 
        ///</summary>
        public void TriangleTestInCorrectParams()
        {
            //set up test 
            Color colour = Color.Black;
            int x = 5;
            int y = 5;
            int side1 = 30;
            int side2 = 55;
            int side3 = 30;
            //create a rectangle
            Triangle t = new Triangle(colour, x, y, side1, side2, side3);
            //check results
            Assert.AreEqual(x, t.x);
            Assert.AreEqual(y, t.y);
            Assert.AreEqual(side1, t.side1);
            Assert.AreNotEqual(30, t.side2);
            Assert.AreEqual(side3, t.side3);
        }
        [TestMethod()]
        ///<summary>
        /// Tests the Triangle method
        /// enters paramaters of maximum size and checks Triangle 
        ///</summary>
        public void TriangleTestMaximumCorrectParams()
        {
            //set up test 
            Color colour = Color.Black;
            int x = 5;
            int y = 5;
            int side1 = 30;
            int side2 = 30;
            int side3 = 2147483647;
            //create a rectangle
            Triangle t = new Triangle(colour, x, y, side1, side1, side3);
            //check results
            Assert.AreEqual(x, t.x);
            Assert.AreEqual(y, t.y);
            Assert.AreEqual(side1, t.side1);
            Assert.AreEqual(side2, t.side2);
            Assert.AreEqual(side3, t.side3);
        }


    }
}