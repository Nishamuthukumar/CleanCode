public class Program
{
    public static void Main(string[] args)
    {
        File file = new File();
        IInputSource inputSource = new FileInputSource(file);
        IPrinter printer = new SimplePrinter();
        PrinterDriver printerDriver = new PrinterDriver(inputSource, printer);
        printerDriver.Print();

        Scanner scanner = new Scanner();
        inputSource = new ScannerInputSource(scanner);
        printerDriver = new PrinterDriver(inputSource, printer);
        printerDriver.Print();

        FaxMachine faxMachine = new FaxMachine();
        inputSource = new FaxInputSource(faxMachine);
        printerDriver = new PrinterDriver(inputSource, printer);
        printerDriver.Print();
    }
}
