using Interview.SSAC.Exercise1.Enums;
using Moq;
using System.Text;

namespace Interview.SSAS.Exercise1.Tests
{
    public class Tests
    {
        private Mock<TextReader> _input;
        private StringBuilder _output;
        private Program _service; 

        [SetUp]
        public void Setup()
        {
            _input = new Mock<TextReader>();
            _output = new StringBuilder();
            _service = new Program();
            Console.SetIn(_input.Object);
            Console.SetOut(new StringWriter(_output));
        }

        #region Happy

        [TestCase("place 0,0,north", "right", "move", "move", "move", "move", "report")]
        [TestCase("place 0,0,east", "move", "move", "move", "move", "report")]
        [TestCase("place 0,0,south", "left", "move", "move", "move", "move", "report")]
        [TestCase("place 0,0,west", "left", "left", "move", "move", "move", "move", "report")]
        [TestCase("place 0,0,west", "right", "right", "move", "move", "move", "move", "report")]
        //40
        public void Move_To_Bottom_Right(params string[] inputs)
        {
            SetupInputs(inputs);
            var outputs = ExecuteMain();

            var actual = outputs[0];

            Assert.That(actual, Is.EqualTo("Output: 4,0,EAST"));
        }

        [TestCase("place 0,0,north", "right", "move", "left", "move", "right", "move", "left", "move", "right", "move", "left", "move", "right", "move", "left", "move", "report")]
        [TestCase("place 0,0,east", "move", "left", "move", "right", "move", "left", "move", "right", "move", "left", "move", "right", "move", "left", "move", "report")]
        //44
        public void Move_To_Top_Right(params string[] inputs)
        {
            SetupInputs(inputs);
            var outputs = ExecuteMain();

            var actual = outputs[0];

            Assert.That(actual, Is.EqualTo("Output: 4,4,NORTH"));
        }

        [TestCase("place 0,0,north", "move", "move", "move", "move", "report")]
        //04
        public void Move_To_Top_Left(params string[] inputs)
        {
            SetupInputs(inputs);
            var outputs = ExecuteMain();

            var actual = outputs[0];

            Assert.That(actual, Is.EqualTo("Output: 0,4,NORTH"));
        }
        #endregion

        #region UnHappy
        [TestCase("right", "move", "right", "move", "left", "move", "right", "move", "left", "move", "right", "move", "left", "move", "right", "move", "report")]
        [TestCase("move", "right", "move", "left", "move", "right", "move", "left", "move", "right", "move", "left", "move", "right", "move", "report")]
        //Robot was not placed on the table
        public void DidNot_Place_Robot(params string[] inputs)
        {
            SetupInputs(inputs);
            var outputs = ExecuteMain();

            var actual = outputs[0];

            Assert.That(actual, Is.EqualTo("Output: Robot was not placed on the table"));
        }

        [TestCase(RobotDirection.SOUTH, "place 0,0,south", "move", "report")]
        [TestCase(RobotDirection.WEST, "place 0,0,west", "move", "report")]
        [TestCase(RobotDirection.SOUTH, "place 0,0,north", "right", "right", "move", "report")]
        //00
        public void Move_Out_Of_Table(RobotDirection facing, params string[] inputs)
        {
            SetupInputs(inputs);
            var outputs = ExecuteMain();

            var actual = outputs[0];

            Assert.That(actual, Is.EqualTo($"Output: 0,0,{facing}"));
        }

        #endregion

        private string[] ExecuteMain()
        {
            Program.Main();
            return _output.ToString().Split("\r\n");
        }

        private MockSequence SetupInputs(params string[] inputs)
        {
            var sequence = new MockSequence();

            foreach(var input in inputs)
            {
                _input.InSequence(sequence).Setup(i => i.ReadLine()).Returns(input);
            }

            return sequence;
        }
    }
}