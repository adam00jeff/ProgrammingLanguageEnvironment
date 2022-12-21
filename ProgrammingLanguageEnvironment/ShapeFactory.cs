using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{
    public class ShapeFactory
    {
        public Shape getShape(String shapeType)
        {
            shapeType = shapeType.ToLower().Trim();

            if (shapeType.Equals("circle"))
            {
                return new Circle();
            }
            else if (shapeType.Equals("rectangle"))
            {
                return new Rectangle();
            }
            else if (shapeType.Equals("triangle"))
            {
                return new Triangle();
            }
            else if (shapeType.Equals("line"))
            {
                return new Line();
            }
            else
            {
                System.ArgumentException argEx = new System.ArgumentException("Factory Error: " + shapeType + "does not exist");
                throw argEx;
            }
        }
    }
}
