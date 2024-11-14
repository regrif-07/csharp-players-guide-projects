internal interface IRobotCommand
{
    public void Run(Robot robot);
}

internal class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

internal class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

internal class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (!robot.IsPowered) return;
        ++robot.Y;
    }
}

internal class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (!robot.IsPowered) return;
        --robot.Y;
    }
}

internal class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (!robot.IsPowered) return;
        --robot.X;
    }
}

internal class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (!robot.IsPowered) return;
        ++robot.X;
    }
}