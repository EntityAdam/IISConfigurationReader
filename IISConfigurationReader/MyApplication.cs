public class MyApplication
{
    public string AppPoolName { get; set; }
    public string Path { get; set; }
    public string EnabledProtocols { get; set; }
    public Dictionary<string, string> AuthenticationModes { get; set; } = new Dictionary<string, string>();
    public List<MyVirtualDirectory> VirtualDirectories { get; set; } = new List<MyVirtualDirectory>();

    internal void Print()
    {
        var indent = " - ";
        if (Path == "/")
        {
            Console.WriteLine($"#### Application: Root");
        }
        else
        {
            Console.WriteLine($"#### Application: {GetLastPart(Path)}");
        }
        Console.WriteLine($"{indent}Path: {Path}");
        Console.WriteLine($"{indent}Application Pool: {AppPoolName}");
        Console.WriteLine($"{indent}Protocol: {EnabledProtocols}");
        Console.WriteLine($"{indent}Authentication Modes:");
        foreach (var mode in AuthenticationModes)
        {
            Console.WriteLine($"  {indent}{mode.Key}: {mode.Value}");
        }
        foreach (var dir in VirtualDirectories)
        {
            dir.Print();
        }
        Console.WriteLine("");
    }
    private static string GetLastPart(string input)
    {
        var index = input.LastIndexOf('/');
        return input.Substring(index + 1);
    }
}
