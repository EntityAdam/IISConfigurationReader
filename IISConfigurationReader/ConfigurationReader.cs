using Microsoft.Web.Administration;

public class ConfigurationReader
{
    private ServerManager _serverManager;
    private List<MySite> _allSites;
    private List<MyApplicationPool> _allAppPools;
    private Configuration _appHostConfiguration;

    public ConfigurationReader()
    {
        _serverManager = new ServerManager();
    }

    public void WriteMarkdownToConsole()
    {
        Read();

        Console.WriteLine("# Sites");
        foreach (var site in _allSites)
        {
            site.Print();
        }

        Console.WriteLine("# Application Pools");
        foreach (var appPool in _allAppPools)
        {
            appPool.Print();
        }
    }

    private void Read()
    {
        _allSites = FetchSiteCollection(_serverManager.Sites);
        _allAppPools = FetchApplicationPoolCollection(_serverManager.ApplicationPools);
        _appHostConfiguration = _serverManager.GetApplicationHostConfiguration();
        FixUpAuthSettings();
    }

    private void FixUpAuthSettings()
    {
        var authenticationModePaths = new string[]
        {
            "system.webServer/security/authentication/basicAuthentication",
            "system.webServer/security/authentication/windowsAuthentication",
            "system.webServer/security/authentication/anonymousAuthentication",
            "system.webServer/security/authentication/clientCertificateMappingAuthentication"
        };

        foreach (var s in _allSites)
        {
            var siteName = s.Name;
            foreach (var a in s.Applications)
            {
                foreach (var mode in authenticationModePaths)
                {
                    var applicationPath = $"{siteName}{a.Path}";
                    var configurationSection = _appHostConfiguration.GetSection(mode, applicationPath);
                    var isAuthModeEnabled = configurationSection["enabled"].ToString();
                    a.AuthenticationModes.Add(mode, isAuthModeEnabled ?? "null");
                }
            }
        }
    }

    private static List<MySite> FetchSiteCollection(SiteCollection siteCollection)
    {
        var mySites = new List<MySite>();
        foreach (var site in siteCollection)
        {
            mySites.Add(FetchSite(site));
        }
        return mySites;
    }
    private static MySite FetchSite(Site site)
    {
        var applications = FetchApplications(site.Applications);
        return new MySite() { Name = site.Name, State = site.State.ToString(), Applications = applications };
    }

    private static List<MyApplication> FetchApplications(ApplicationCollection applicationCollection)
    {
        var myApplications = new List<MyApplication>();
        foreach (var application in applicationCollection)
        {
            myApplications.Add(FetchApplication(application));
        }
        return myApplications;
    }

    private static MyApplication FetchApplication(Application application)
    {
        return new() { AppPoolName = application.ApplicationPoolName, Path = application.Path, EnabledProtocols = application.EnabledProtocols, VirtualDirectories = FetchVirtualDirectories(application.VirtualDirectories) };
    }

    private static List<MyVirtualDirectory> FetchVirtualDirectories(VirtualDirectoryCollection virtualDirectoryCollection)
    {
        var myVirtualDirectories = new List<MyVirtualDirectory>();
        foreach (var virtualDirectory in virtualDirectoryCollection)
        {
            myVirtualDirectories.Add(FetchVirtualDirectory(virtualDirectory));
        }
        return myVirtualDirectories;
    }

    private static MyVirtualDirectory FetchVirtualDirectory(VirtualDirectory virtualDirectory)
    {
        return new() { Path = virtualDirectory.Path, PhysticalPath = virtualDirectory.PhysicalPath };
    }

    private static List<MyBinding> FetchBindings(BindingCollection bindingCollection)
    {
        var myBindings = new List<MyBinding>();
        foreach (var binding in bindingCollection)
        {
            myBindings.Add(FetchBinding(binding));
        }
        return myBindings;
    }

    private static MyBinding FetchBinding(Binding binding)
    {
        return new() { BindingInfo = binding.BindingInformation, Protocol = binding.Protocol };
    }

    private static List<MyApplicationPool> FetchApplicationPoolCollection(ApplicationPoolCollection applicationPools)
    {
        var myApplicationPools = new List<MyApplicationPool>();
        foreach (var applicationPool in applicationPools)
        {
            myApplicationPools.Add(FetchApplicationPool(applicationPool));
        }
        return myApplicationPools;
    }

    private static MyApplicationPool FetchApplicationPool(ApplicationPool applicationPool)
    {
        return new()
        {
            Name = applicationPool.Name,
            Enable32Bit = applicationPool.Enable32BitAppOnWin64.ToString(),
            ManagedPipelineMode = applicationPool.ManagedPipelineMode.ToString(),
            ManagedRuntimeVersion = applicationPool.ManagedRuntimeVersion
        };
    }
}