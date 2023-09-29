public class Package
{
    public String packageName {get; set; }
    public String version {get; set; }    
    public Boolean canBeInstalled {get; set; } 

    public List<Package> dependencies{get;}

    public Package(String inputLine)
    {
        int i = 0;
        inputLine = inputLine.Trim();
        string[] s = inputLine.Split(",");
        packageName = s[i++];
        version = s[i++];
        if (s.Length > i) {
            dependencies = new List<Package>();
            while(s.Length > i) {
                Package dependency = new Package(s[i++], s[i++]);
                dependencies.Add(dependency);
            }
        }
        canBeInstalled = true;
    }

    public Package(string packageName, string version)
    {
        this.packageName = packageName;
        this.version = version;
    }
}