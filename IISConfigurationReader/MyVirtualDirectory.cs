public class MyVirtualDirectory
{
    public string Path { get; set; }
    public string PhysticalPath { get; set; }

    internal void Print()
    {
        var indent = "   - ";
        Console.WriteLine($" - Virtual Directory:");
        Console.WriteLine($"{indent}Path: {Path}");
        Console.WriteLine($"{indent}Physical Path: {PhysticalPath}");
    }
}
