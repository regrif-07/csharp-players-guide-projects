internal class Door
{
    private string _passcode;

    public Door(string passcode)
    {
        _passcode = passcode;
    }

    public enum DoorState
    {
        Locked,
        Closed,
        Open,
    }

    public DoorState State { get; private set; }

    public void DisplayStatus()
    {
        Console.WriteLine($"The door is {State.ToString().ToLower()}.");
    }

    public bool Close()
    {
        if (State == DoorState.Open)
        {
            State = DoorState.Closed;
            return true;
        }

        return false;
    }

    public bool Open()
    {
        if (State == DoorState.Closed)
        {
            State = DoorState.Open;
            return true;
        }

        return false;
    }

    public bool Lock()
    {
        if (State == DoorState.Closed)
        {
            State = DoorState.Locked;
            return true;
        }

        return false;
    }

    public bool Unlock(string passcode)
    {
        if (State == DoorState.Locked && passcode == _passcode)
        {
            State = DoorState.Closed;
            return true;
        }

        return false;
    }

    public bool ChangePasscode(string oldPasscode, string newPasscode)
    {
        if (oldPasscode == _passcode)
        {
            _passcode = newPasscode;
            return true;
        }

        return false;
    }
}
