using Interview.SSAC.Exercise1.Handlers;

class Program
{
    public static void Main()
    {
        var invoker = new CommandInvoker();
        invoker.InitRobot();

        do
        {
            invoker.AddCommand(Console.ReadLine()?.ToUpper());
        }
        while (!invoker.IsEoC);

        invoker.ExecuteCommands();
    }
}

