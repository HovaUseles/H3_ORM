namespace H3_ORM___Code_first.GUI;

public class FileExists : Exception
{
    public FileExists() { }

    public FileExists(string message) : base(message) { }
}

public class InputAttempsExceeded : Exception
{
    public InputAttempsExceeded() { }

    public InputAttempsExceeded(string message) : base(message) { }
}
