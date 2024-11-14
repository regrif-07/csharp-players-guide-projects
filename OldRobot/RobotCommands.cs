internal abstract class RobotCommand
{
    abstract public void Run(Robot robot);
}

internal class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

internal class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

internal class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (!robot.IsPowered) return;
        ++robot.Y;
    }
}

internal class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (!robot.IsPowered) return;
        --robot.Y;
    }
}

internal class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (!robot.IsPowered) return;
        --robot.X;
    }
}

internal class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (!robot.IsPowered) return;
        ++robot.X;
    }
}