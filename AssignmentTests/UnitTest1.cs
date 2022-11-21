using AssignmentApp;
using System.Windows.Forms;

namespace AssignmentTests
{
    [TestClass]
    public class AssignmentTests
    {
        /// <summary>
        /// The following tests are for the main Assignment Project.
        /// including tests for the Parser and Canvas
        /// </summary>
        
        [TestMethod]

        /// <summary>
        /// These test the parser commands and how it handles the information given
        /// tests are for moveTo command, drawTo command, circle and square.
        /// tests Canvas class for accurate getX and Y positions.
        /// </summary>
        public void ParserTestMoveTo()
        {
            Canvas c = new Canvas();
            Parser p = new Parser(c);

            String commands = "moveto 45 100";

            p.Parse(commands);

            Assert.AreEqual(45, c.cursorX);
            Assert.AreEqual(100, c.cursorY);
        }

        [TestMethod]

        // checks to see if the drawTo command moved the cursor from the origin to the correct end point

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
        [TestMethod]


        //Checks that when invalid parameters are parsed, an exception is thrown

        public void ParserInvalidParameterTest() 
        {
            Canvas c = new Canvas();
            Parser p = new Parser(c);

            String commands = "moveto ab ab";

            Assert.ThrowsException<FormatException>(() => p.Parse(commands));
        }


    }
}