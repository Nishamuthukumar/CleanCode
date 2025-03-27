public interface IPrinter
{
    void Print(Buffer page);  
}

public class PrinterDriver
{
    private readonly IInputSource _inputSource;
    private readonly IPrinter _printer;

    public PrinterDriver(IInputSource inputSource, IPrinter printer)
    {
        _inputSource = inputSource;
        _printer = printer;
    }

    public void Print()
    {
        Buffer page = _inputSource.ReadPage();
        while (!_inputSource.IsEndOfSource(page))
        {
            _printer.Print(page);
            page = _inputSource.ReadPage();
        }
    }
}

public class SimplePrinter : IPrinter
{
    public void Print(Buffer page)
    {
        Console.WriteLine("Printing page...");
    }
}
