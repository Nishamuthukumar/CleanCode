public interface IInputSource
{
    Buffer ReadPage();   
    bool IsEndOfSource(Buffer page);  
}

public class FileInputSource : IInputSource
{
    private readonly File _file;

    public FileInputSource(File file)
    {
        _file = file;
    }

    public Buffer ReadPage()
    {
      
        return _file.ReadPage();
    }

    public bool IsEndOfSource(Buffer page)
    {
        return _file.IsEndOfFile(page);
    }
}

public class File
{
    public Buffer ReadPage()
    {
        return new Buffer();
    }

    public bool IsEndOfFile(Buffer page)
    {
        return false;
    }
}

public class Buffer
{
    // A class to represent the data for a page
}
