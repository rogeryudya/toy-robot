using Interview.SSAC.Exercise1.Enums;
using Interview.SSAC.Exercise1.Models;

namespace Interview.SSAC.Exercise1.Handlers;

internal class CommandInvoker
{
    private Robot _robot;
    private List<Command> commands = new List<Command>();

    /// <summary>
    /// The end of command
    /// </summary>
    public bool IsEoC { get; private set; }

    public void InitRobot()
    {
        _robot = new Robot();
    }

    public void AddCommand(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid command");
        }

        string[] parts = input.Split(' ');
        Enum.TryParse<CommandType>(parts[0].Trim(), out var command);

        switch (command)
        {
            case CommandType.PLACE:
                commands.Add(new PlaceCommand(_robot, parts));
                break;
            case CommandType.MOVE:
                commands.Add(new MoveCommand(_robot));
                break;
            case CommandType.LEFT:
                commands.Add(new RotateCommand(_robot, -1));
                break;
            case CommandType.RIGHT:
                commands.Add(new RotateCommand(_robot, +1));
                break;
            case CommandType.REPORT:
                commands.Add(new ReportCommand(_robot));
                IsEoC = true;
                break;
        }
    }

    public void ExecuteCommands() 
    {
        foreach (var cmd in commands) 
        {
            cmd.Execute();
        }
    }
}
