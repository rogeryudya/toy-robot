using Interview.SSAC.Exercise1.Enums;
using Interview.SSAC.Exercise1.Models;

namespace Interview.SSAC.Exercise1.Handlers;

internal class PlaceCommand : Command
{
    private Robot _robot;
	private int _x;
	private int _y;
	private RobotDirection _direction;
	private string[] _parts;

    public PlaceCommand(Robot robot, string[] parts)
	{
		_robot = robot;
        _parts = parts;
    }

	public override void Execute()
	{
        if (TryParseCommandArgument(_parts))
		{
            _robot.PositionX = _x;
            _robot.PositionY = _y;
            _robot.Facing = _direction;
        }
	}

	private bool TryParseCommandArgument(string[] parts)
	{
		if (parts.Count() != 2)
		{
			return false;
		}

		var args = parts[1].Split(',');

		if (args.Count() != 3 || 
			!int.TryParse(args[0], out var x) || 
			!int.TryParse(args[1], out var y) ||
			!Enum.TryParse(args[2], out RobotDirection direction))
        {
            return false;
        }

		_x = x;
		_y = y;
        _direction = direction;

		return true;
    }
}
