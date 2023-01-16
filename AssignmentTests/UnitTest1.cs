using AssignmentApp;
using System.Drawing;
using System.Windows.Forms;

namespace AssignmentTests
{
    /// <summary>The following tests are for the main Assignment Project, including tests for the Parser and Canvas<br /></summary>
    [TestClass]
    public class AssignmentTests
    {
        /// <summary>
        /// The following tests are for the main Assignment Project.
        /// including tests for the Parser and Canvas
        /// </summary>

        [TestMethod]
        public void ParserTestMoveTo()
        {
            Canvas c = new Canvas();
            Parser p = new Parser(c);

            String commands = "moveto 45 100";

            p.Parse(commands);

            Assert.AreEqual(45, c.cursorX);
            Assert.AreEqual(100, c.cursorY);
        }

        // checks to see if the drawTo command moved the cursor from the origin to the correct end point
        [TestMethod]
        public void ParserTestDrawTo()
        {
            Canvas c = new Canvas();
            Parser p = new Parser(c);

            String commands = "drawto 45 100";

            Assert.AreEqual(0, c.cursorX);
            Assert.AreEqual(0, c.cursorY);

            p.Parse(commands);

            Assert.AreEqual(45, c.cursorX);
            Assert.AreEqual(100, c.cursorY);
        }

        //tests the canvas drawTriangle method is parsing the information correctly
        [TestMethod]
        public void CanvasTriangleFunctionality()
        {
            Canvas c = new Canvas();

            c.DrawTriangle(100);

            Assert.AreEqual(0, c.x);
            Assert.AreEqual(0, c.y);
            Assert.AreEqual(100, c.size);

        }

        //tests the canvas drawRectangle method is parsing height and width correctly
        [TestMethod]
        public void CanvasRectangleFunctionality()
        {
            Canvas c = new Canvas();

            c.DrawRect(100, 100);

            Assert.AreEqual(100, c.height);
            Assert.AreEqual(100, c.width);
        }

        //tests the canvas drawCircle method is parsing radius correctly
        [TestMethod]
        public void CanvasCircleFunctionality()
        {
            Canvas c = new Canvas();

            c.DrawCircle(100);

            Assert.AreEqual(100, c.radius);
        }

        //tests the canvas changePen method is correctly changing the pen color to the one inputted, regardless of case or trim.
        [TestMethod]
        public void PenColorFunctionality()
        {
            Canvas c = new Canvas();

            c.ChangePen("Red");

            Assert.AreEqual(Color.Red, c.Pen.Color);

            c.ChangePen("green");

            Assert.AreEqual(Color.Green, c.Pen.Color);

            //checks for casing
            c.ChangePen("BlUe");

            Assert.AreEqual(Color.Blue, c.Pen.Color);
        }





        /// <summary>
        /// Tests below this point are more aimed towards part two of the assignment
        /// </summary>

        //checks the functionality multiline input
        [TestMethod]
        public void ParserMultiLineFunction()
        {
            Canvas c = new Canvas();
            Parser p = new Parser(c);

            c.cursorX = 0;
            c.cursorY = 0;

            string command = "circle 100\nmoveto 200 200\ntriangle 100";

            p.Parse(command);

            Assert.AreEqual(200, c.cursorX);
            Assert.AreEqual(200, c.cursorY);
        }

        //ensures that the program counter is counting correctly, essential for loops and methods.
        [TestMethod]
        public void ParserProgramCounter()
        {
            Canvas c = new Canvas();
            Parser p = new Parser(c);

            string command = "method test\nmeth end\nvar x\nx = 100\ncircle x";
            p.Parse(command);

            Assert.AreEqual(5, p.programCounter);
        }







        //this tests checks the clear method within the parser that clears saved variables
        //parameters, methods and all positions as not to confuse the duplicate variable check
        [TestMethod]
        public void ParserClearSavedPositions()
        {
            Canvas c = new Canvas();
            Parser p = new Parser(c);

            string command = "method test\nmeth end\nvar x\nx = 100\ncircle x";
            p.Parse(command);

            Assert.AreEqual(1,p.methodCounter);
            Assert.AreEqual(1,p.variableCounter);

            p.Clear();

            Assert.AreEqual(0, p.methodCounter);
            Assert.AreEqual(0, p.variableCounter);
        }

        //checks the VariableCounter is counting correctly and finding the correct variable when called
        [TestMethod]
        public void ParserVariablesCounter()
        {
            Canvas c = new Canvas();
            Parser p = new Parser(c);

            string command = "method test\nmeth end\nvar x\nx = 100\ncircle x";
            p.Parse(command);

            Assert.AreEqual(1, p.variableCounter);
        }

        //checks the MethodCounter is counting correctly and finding the correct method when called
        [TestMethod]
        public void ParserMethodsCounter()
        {
            Canvas c = new Canvas();
            Parser p = new Parser(c);

            string command = "method test\nmeth end\nvar x\nx = 100\ncircle x";
            p.Parse(command);

            Assert.AreEqual(1, p.methodCounter);
        }

        //ensures the CheckVariables method finds the correct variables
        [TestMethod]
        public void ParserCheckVariables()
        {
            Canvas c = new Canvas();
            Parser p = new Parser(c);

            string command = "method test\nmeth end\nvar x\nx = 100\ncircle x";

            int i = p.checkVariables("x");

            Assert.AreEqual(-1, i);
            p.Parse(command);

            i = p.checkVariables("x");
            Assert.AreEqual(0, i);
        }

        //ensures the CheckMethod method finds the correct methods
        [TestMethod]
        public void ParserCheckMethods()
        {
            Canvas c = new Canvas();
            Parser p = new Parser(c);

            string command = "method test\ncircle 100\nmeth end\nvar x\nx = 100\ncircle x";

            int i = p.checkMethod("test");

            Assert.AreEqual(-1, i);

            p.Parse(command);

            i = p.checkMethod("test");
            Assert.AreEqual(0, i);
        }
    }
}