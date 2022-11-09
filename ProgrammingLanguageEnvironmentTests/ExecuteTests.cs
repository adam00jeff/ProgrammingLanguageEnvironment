using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgrammingLanguageEnvironment;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment.Tests
{
    /// <summary>
    /// tests for the execute class
    /// tests the execute parse method
    /// execute parse calls other methods form parser class
    /// parses input line by line 
    /// </summary>
    [TestClass()]
    public class ExecuteTests
    {
        [TestMethod()]
        ///<summary>
        /// Tests Execute Parse
        /// Enters a correct Rectangle command
        /// </summary>
        public void ExecuteParseTestRectangleCorrectParamaters()
        {
            //set up test
            var input = "Rectangle 50, 50";
            ArrayList shapes = new ArrayList();
            Rectangle expected = new Rectangle(Color.Black, 0, 0, 50, 50);
            //calls the method
            var result = Execute.ExecuteParse(input, shapes);
            //checks the result
            Assert.IsNotNull(result);
            Assert.AreEqual(1, shapes.Count);
            Assert.IsInstanceOfType(shapes[0], typeof(Shape));
            Assert.IsInstanceOfType(shapes[0], typeof(Rectangle));
            Rectangle s = (Rectangle)shapes[0];//passes the result back to a rectangle
            Assert.AreEqual(s.width, 50);
            Assert.AreEqual(s.height, 50);
            Assert.AreEqual(s.x, 0);
            Assert.AreEqual(s.y, 0);
            Assert.AreEqual(s.colour, Color.Black);
        }
        [TestMethod()]
        ///<summary>
        /// Tests Execute Parse
        /// Enters a correct command
        /// </summary>
        public void ExecuteParseTestCircleCorrectParamaters()
        {
            //set up test
            var input = "Circle 50";
            ArrayList shapes = new ArrayList();
            Circle expected = new Circle(Color.Black, 0, 0, 50);
            //calls the method
            var result = Execute.ExecuteParse(input, shapes);
            //checks the result
            Assert.IsNotNull(result);
            Assert.AreEqual(1, shapes.Count);
            Assert.IsInstanceOfType(shapes[0], typeof(Shape));
            Assert.IsInstanceOfType(shapes[0], typeof(Circle));
            Circle s = (Circle)shapes[0];//passes the result back to a rectangle
            Assert.AreEqual(s.radius, 50);
            Assert.AreEqual(s.x, 0);
            Assert.AreEqual(s.y, 0);
            Assert.AreEqual(s.colour, Color.Black);
        }
        [TestMethod()]
        ///<summary>
        /// Tests Execute Parse
        /// Enters a correct command
        /// </summary>
        public void ExecuteParseTestTriangleCorrectParamaters()
        {
            //set up test
            var input = "Triangle 50 50 50";
            ArrayList shapes = new ArrayList();
            Triangle expected = new Triangle(Color.Black, 0, 0, 50,50,50);
            //calls the method
            var result = Execute.ExecuteParse(input, shapes);
            //checks the result
            Assert.IsNotNull(result);
            Assert.AreEqual(1, shapes.Count);
            Assert.IsInstanceOfType(shapes[0], typeof(Shape));
            Assert.IsInstanceOfType(shapes[0], typeof(Triangle));
            Triangle t = (Triangle)shapes[0];//passes the result back to a rectangle
            Assert.AreEqual(t.side1, 50);
            Assert.AreEqual(t.side2, 50);
            Assert.AreEqual(t.side3, 50);
            Assert.AreEqual(t.x, 0);
            Assert.AreEqual(t.y, 0);
            Assert.AreEqual(t.colour, Color.Black);
        }
        [TestMethod()]
        ///<summary>
        /// Tests Execute Parse
        /// Enters a correct command
        /// </summary>
        public void ExecuteParseTestLineCorrectParamaters()
        {
            //set up test
            var input = "Line 100,100";
            ArrayList shapes = new ArrayList();
            Line expected = new Line(Color.Black, 0, 0, 50,50);
            //calls the method
            var result = Execute.ExecuteParse(input, shapes);
            //checks the result
            Assert.IsNotNull(result);
            Assert.AreEqual(1, shapes.Count);
            Assert.IsInstanceOfType(shapes[0], typeof(Shape));
            Assert.IsInstanceOfType(shapes[0], typeof(Line));
            Line l = (Line)shapes[0];//passes the result back to a rectangle
            Assert.AreEqual(l.tox, 100);
            Assert.AreEqual(l.toy, 100);
            Assert.AreEqual(l.x, 0);
            Assert.AreEqual(l.y, 0);
            Assert.AreEqual(l.colour, Color.Black);
        }
        [TestMethod()]
        ///<summary>
        /// Tests Execute Parse
        /// Enters an incorrect command
        /// </summary>
        public void ExecuteParseTestIncorrectParamaters()
        {
            //set up test
            ArrayList shapes = new ArrayList();
            var input = "Cabbage 50, 50";
           //calls the method
            var result = Execute.ExecuteParse(input, shapes);
            //checks the result
            Assert.IsNotNull(result);
            Assert.AreEqual(0, shapes.Count);
        }
        [TestMethod()]
        ///<summary>
        /// Tests Execute Parse
        /// Enters an incorrect command
        /// </summary>
        public void ExecuteParseTestIncorrectParamatersmixed()
        {
            //set up test
            ArrayList shapes = new ArrayList();
            var input = "Cabbage 50rat, 50squirrel";
            //calls the method
            var result = Execute.ExecuteParse(input, shapes);
            //checks the result
            Assert.IsNotNull(result);
            Assert.AreEqual(0, shapes.Count);
        }
        [TestMethod()]
        ///<summary>
        /// Tests Execute Parse
        /// Enters an incorrect command
        /// </summary>
        public void ExecuteParseTestIncorrectSymbolsmixed()
        {
            //set up test
            ArrayList shapes = new ArrayList();
            var input = "!2....           @@@@@@@###";
            //calls the method
            var result = Execute.ExecuteParse(input, shapes);
            //checks the result
            Assert.IsNotNull(result);
            Assert.AreEqual(0, shapes.Count);
        }
    }
}