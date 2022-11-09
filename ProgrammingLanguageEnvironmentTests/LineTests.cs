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
    /// <summary>
    /// tests for the line class
    /// </summary>
    [TestClass()]
    public class LineTests
    {
        /// <summary>
        /// tests to create lines
        /// enters correct paramaters
        /// </summary>
        [TestMethod()]
        public void LineTest()
        {
            //set up test 
            Color colour = Color.Black;
            int x = 5;
            int y = 5;
            int tox = 30;
            int toy = 30;
            //create a line
            Line l = new Line(colour, x, y, tox, toy);
            //check results
            Assert.AreEqual(x, l.x);
            Assert.AreEqual(y, l.y);
            Assert.AreEqual(tox, l.tox);
            Assert.AreEqual(toy, l.toy);


        }
    }
}