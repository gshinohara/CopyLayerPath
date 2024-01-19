using Rhino.PlugIns;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Plug-in Description Attributes - all of these are optional.
// These will show in Rhino's option dialog, in the tab Plug-ins.
[assembly: PlugInDescription(DescriptionType.Address, "")]
[assembly: PlugInDescription(DescriptionType.Country, "")]
[assembly: PlugInDescription(DescriptionType.Email, "")]
[assembly: PlugInDescription(DescriptionType.Phone, "")]
[assembly: PlugInDescription(DescriptionType.Fax, "")]
[assembly: PlugInDescription(DescriptionType.Organization, "")]
[assembly: PlugInDescription(DescriptionType.UpdateUrl, "")]
[assembly: PlugInDescription(DescriptionType.WebSite, "")]

// Icons should be Windows .ico files and contain 32-bit images in the following sizes: 16, 24, 32, 48, and 256.
[assembly: PlugInDescription(DescriptionType.Icon, "CopyLayerPath.EmbeddedResources.plugin-utility.ico")]

// The following GUID is for the ID of the typelib if this project is exposed to COM
// This will also be the Guid of the Rhino plug-in
[assembly: Guid("48ae55e3-4286-4fe8-9723-d97ad5b42e34")]
