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
        [TestMethod()]
        public void RectangleTestCorrectParams()
        {
            //set up test 
            var colour = Color.Black;
            int x = 5;
            int y = 5;
            int width = 30;
            int height = 30;
            //create a rectangle
            Rectangle r = new Rectangle(x, y, width, height);
            //check results
            Assert.AreEqual(x, r.X);
            Assert.AreEqual(y, r.Y);
            Assert.AreEqual(width, r.Width);
            Assert.AreEqual(height, r.Height);
        }
        

    }
}