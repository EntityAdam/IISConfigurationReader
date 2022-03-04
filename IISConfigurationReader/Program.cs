using Microsoft.Web.Administration;

Console.WriteLine("IIS Configuration Reader - adam.vincent@ais.com");
Console.WriteLine("");
Console.WriteLine($"Machine Name: {System.Environment.MachineName}");

ConfigurationReader reader = new();
reader.WriteMarkdownToConsole();

Console.WriteLine("Press any key to exit..");
Console.ReadKey();