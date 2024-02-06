using Interview.SSAC.Exercise1.Constants;
using Interview.SSAC.Exercise1.Enums;
using Interview.SSAC.Exercise1.Models;

namespace Interview.SSAC.Exercise1.Handlers;

internal class MoveCommand : Command
{
    private Robot _robot;

    public MoveCommand(Robot robot)
    {
        _robot = robot;
    }

    public override void Execute()
    {
        if (_robot.IsValid)
        {
            switch (_robot.Facing)
            {
                case RobotDirection.NORTH:
                    _robot.PositionY = Math.Min(_robot.PositionY.Value + 1, CommandConst.TABLE_MAX_Y - 1);
                    break;
                case RobotDirection.EAST:
                    _robot.PositionX = Math.Min(_robot.PositionX.Value + 1, CommandConst.TABLE_MAX_X - 1);
                    break;
                case RobotDirection.SOUTH:
                    _robot.PositionY = Math.Max(_robot.PositionY.Value - 1, 0);
                    break;
                case RobotDirection.WEST:
                    _robot.PositionX = Math.Max(_robot.PositionX.Value - 1, 0);
                    break;
            }
        }
    }
}
