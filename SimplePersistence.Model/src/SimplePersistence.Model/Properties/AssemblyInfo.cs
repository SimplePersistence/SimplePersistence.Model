using System;
using System.Reflection;
using System.Runtime.InteropServices;

#if PORTABLE40
[assembly: AssemblyTitle("SimplePersistence.Model Portable .NET 4.0")]
#elif PORTABLE
[assembly: AssemblyTitle("SimplePersistence.Model Portable")]
#elif DOTNET
[assembly: AssemblyTitle("SimplePersistence.Model .NET Platform")]
#elif NET20
[assembly: AssemblyTitle("SimplePersistence.Model .NET 2.0")]
#elif NET35
[assembly: AssemblyTitle("SimplePersistence.Model .NET 3.5")]
#elif NET40
[assembly: AssemblyTitle("SimplePersistence.Model .NET 4.0")]
#else
[assembly: AssemblyTitle("SimplePersistence.Model")]
#endif

[assembly: AssemblyDescription("Library with helper interfaces and classes to provide consistency across application models. Implementations are ORM compatible and should be usable in most databases.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Net.JoaoSimoes")]
[assembly: AssemblyProduct("SimplePersistence")]
[assembly: AssemblyCopyright("Copyright © 2016 SimplePersistence")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

#if !(PORTABLE40 || PORTABLE)

[assembly: ComVisible(false)]

[assembly: Guid("26bf2ceb-dec6-43c8-a94d-6d993ea9ffe6")]

#endif

[assembly: CLSCompliant(true)]

[assembly: AssemblyVersion("3.0.0")]
[assembly: AssemblyInformationalVersion("3.0.0")]
