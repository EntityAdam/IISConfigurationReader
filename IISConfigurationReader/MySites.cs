
//ServerManager serverManager = new();
//var sites = serverManager.Sites;

//foreach (var site in sites)
//{
//    var mySite = new MySite();
//    mySite.Name = site.Name;
//    mySite.State = site.State.ToString();

//    var applications = site.Applications;
//    foreach (var application in applications)
//    {
//        var appDetail = new MyApplication();
//        appDetail.AppPoolName = application.ApplicationPoolName;
//        var b = application.EnabledProtocols;
//        appDetail.Path = application.Path;
//        appDetail.PhysicalPath = application.VirtualDirectories[0].PhysicalPath;
//        var e = application.VirtualDirectoryDefaults;
//        mySite.Applications.Add(appDetail);
//    }

//    //var x = serverManager.GetApplicationHostConfiguration();
//    //var isapiFilters = x.GetSection("system.webServer/isapiFilters");

//    var bindings = site.Bindings;
//    foreach (var binding in bindings)
//    {
//        Console.WriteLine($"{binding.Protocol}");
//    }


//    //foreach (var attr in attribs)
//    //{
//    //    Console.WriteLine($"{attr.Name} {attr.Value}");
//    //}

//    foreach (var app in site.Applications)
//    {
//        var appPool = app.ApplicationPoolName;
//        var attributes1 = app.Attributes;

//        var proto = app.EnabledProtocols;


//        Console.WriteLine($"-> {app.Path}");
//        var virualDirectories = app.VirtualDirectories;
//        foreach (var dir in virualDirectories)
//        {
//            var path = dir.Path;
//            var physicalPath = dir.PhysicalPath;
//        }
//    }
//}

public class MySites
{
    private List<MySite> mySites;
}
