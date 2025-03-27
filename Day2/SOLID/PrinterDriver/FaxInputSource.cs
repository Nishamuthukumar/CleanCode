public class FaxInputSource : IInputSource
{
    private readonly FaxMachine _faxMachine;

    public FaxInputSource(FaxMachine faxMachine)
    {
        _faxMachine = faxMachine;
    }

    public Buffer ReadPage()
    {
        return _faxMachine.ReceiveFax();
    }

    public bool IsEndOfSource(Buffer page)
    {
        return _faxMachine.IsEndOfFax(page);
    }
}

public class FaxMachine
{
    public Buffer ReceiveFax()
    {
        return new Buffer();
    }

    public bool IsEndOfFax(Buffer page)
    {
        return false;
    }
}
