namespace ConfigitSolution.Services;

public class PackageAnalyzer{

    public Boolean analyzePackage(String input)
    {

        string[] strings = input.Split("\n");
        List<String> inputStrings = new List<string>(strings);
        int counter = 0;
        int numberPackagesToInstall = int.Parse(inputStrings[counter++]);
        List<Package> packagesToInstall = new List<Package>();
        List<Package> dependencies = new List<Package>();
        for (int i = 0; i < numberPackagesToInstall; i++) {
            String line = inputStrings[counter++];
            Package p = new Package(line);
            packagesToInstall.Add(p);

        }

        if (counter < inputStrings.Count)
        {
            int numberOfDependencies = int.Parse(inputStrings[counter++]);
            for (int i = 0; i < numberOfDependencies; i++)
            {
                String line = inputStrings[counter++];
                Package p = new Package(line);
                dependencies.Add(p);
            
            }
        }
       
        var packageVersions = packagesToInstall.ToDictionary(p => p.packageName, p => p.version);

        return analyzeDependency(packageVersions, dependencies);
    }



    public bool analyzeDependency(Dictionary<string, string> packageVersions, List<Package> dependencies)
    {
        foreach (var dependency in dependencies)
        {
            if (packageVersions.ContainsKey(dependency.packageName) &&
                packageVersions[dependency.packageName].Equals(dependency.version))
            {
                Dictionary<string, string> dependencyVersions;
                if (dependency.dependencies != null)
                {
                    dependencyVersions = dependency.dependencies.ToDictionary(p => p.packageName, p => p.version);
                    if (dependencyVersions.ContainsKey(dependency.packageName) &&
                        !dependencyVersions[dependency.packageName].Equals(dependency.version))
                    {
                        return false;
                    }
                    else
                    {
                        foreach (var deps in dependencyVersions)
                        {
                            if (!(packageVersions.ContainsKey(deps.Key)))
                            {
                                packageVersions.Add(deps.Key, deps.Value);
                            }
                            else if (packageVersions.ContainsKey(deps.Key) && packageVersions[deps.Key] != deps.Value)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
        }
    return true;
    
}


}