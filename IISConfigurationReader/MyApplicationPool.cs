public class MyApplicationPool
{
    public string Name { get; set; }
    public string Enable32Bit { get; set; }
    public string ManagedPipelineMode { get; set; }
    public string ManagedRuntimeVersion { get; set; }

    internal void Print()
    {
        const string indent = " - ";
        Console.WriteLine($"App Pool: {Name}");
        Console.WriteLine($"{indent}Enable32Bit: {Enable32Bit}");
        Console.WriteLine($"{indent}ManagedPipelineMode: {ManagedPipelineMode}");
        Console.WriteLine($"{indent}ManagedRuntimeVersion: {ManagedRuntimeVersion}");
        Console.WriteLine();
    }
}
