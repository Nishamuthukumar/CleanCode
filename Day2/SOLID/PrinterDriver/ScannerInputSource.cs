public class ScannerInputSource : IInputSource
{
    private readonly Scanner _scanner;

    public ScannerInputSource(Scanner scanner)
    {
        _scanner = scanner;
    }

    public Buffer ReadPage()
    {
        return _scanner.ScanPage();
    }

    public bool IsEndOfSource(Buffer page)
    {
        return _scanner.IsEndOfScan(page);
    }
}

public class Scanner
{
    public Buffer ScanPage()
    {
        return new Buffer();
    }

    public bool IsEndOfScan(Buffer page)
    {
        return false;
    }
}
