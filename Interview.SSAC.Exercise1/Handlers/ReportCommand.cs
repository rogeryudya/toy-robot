using Interview.SSAC.Exercise1.Models;

namespace Interview.SSAC.Exercise1.Handlers;

internal class ReportCommand : Command
{
    private Robot _robot;

    public ReportCommand(Robot robot)
    {
        _robot = robot;
    }

    public override void Execute()
    {
        var msg = !_robot.IsValid ? 
            "Robot was not placed on the table" :
            $"{_robot.PositionX},{_robot.PositionY},{_robot.Facing}";

        Console.WriteLine($"Output: {msg}");
    }
}
