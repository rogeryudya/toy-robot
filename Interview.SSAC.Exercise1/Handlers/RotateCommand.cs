using Interview.SSAC.Exercise1.Enums;
using Interview.SSAC.Exercise1.Models;

namespace Interview.SSAC.Exercise1.Handlers;

internal class RotateCommand : Command
{
    private Robot _robot;
    private readonly int _rotateDiection;

    public RotateCommand(Robot robot, int rotateDiection)
    {
        _robot = robot;
        _rotateDiection = rotateDiection;
    }

    public override void Execute()
    {
        if (_robot.IsValid)
        {
            var rotated = (int)_robot.Facing + _rotateDiection;
            _robot.Facing = rotated < 0 ? RobotDirection.WEST : (RobotDirection)(rotated % 4);
        }
    }
}
