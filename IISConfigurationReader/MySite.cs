public class MySite
{
    public string Name { get; set; }
    public string State { get; set; }
    public List<MyApplication> Applications { get; set; } = new List<MyApplication>();

    public void Print()
    {
        Console.WriteLine($"## Site: {Name}");
        Console.WriteLine($"State: {State}");
        Console.WriteLine("");
        Console.WriteLine($"Applications:");
        foreach (var app in Applications)
        {
            app.Print();
        }
    }
}
