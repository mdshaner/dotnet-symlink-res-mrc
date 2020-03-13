# dotnet-symlink-res-mrc
Minimum Reproduction Case for a dotnet embedded resource issue with symlinks

# Components
Utilizing a resx with PublicResXFileCodeGenerator and a CustomToolNamespace specified and building the resources across a symlink

# How to reproduce
Move the Resources directory to another location (~/Resources) and create a symlink to it instead
`ln -s ~/Resources ./Resources`

After that within the TestRunner project, `dotnet clean; dotnet build; dotnet run`

# Stacktrace of issue

>Unhandled exception. System.Resources.MissingManifestResourceException: Could not find the resource "Resources.resx.Common.Common.resources" among the resources "Resources.Common.resources" embedded in the assembly "Resources", nor among the resources in any satellite assemblies for the specified culture. Perhaps the resources were embedded with an incorrect name.
>   at System.Resources.ManifestBasedResourceGroveler.HandleResourceStreamMissing(String fileName)
>   at System.Resources.ManifestBasedResourceGroveler.GrovelForResourceSet(CultureInfo culture, Dictionary`2 localResourceSets, Boolean tryParents, Boolean createIfNotExists)
>   at System.Resources.ResourceManager.InternalGetResourceSet(CultureInfo culture, Boolean createIfNotExists, Boolean tryParents)
>   at System.Resources.ResourceManager.GetString(String name, CultureInfo culture)
>   at CustomNamespace.Common.get_Test() in /Users/devusr/Work/Resources/resx/Common/Common.Designer.cs:line 52
>   at TestRunner.Program.Main(String[] args) in /Users/devusr/Newish/TestApp/TestRunner/Program.cs:line 101

# Observations of questionable value
The obj/Debug/netstandard2.0 directory appears to have the .resource files as `Resources.Common.resources` when built across the symlink from TestRunner as opposed to `Resources.resx.Common.Common.resources` when built from the Resources directory.