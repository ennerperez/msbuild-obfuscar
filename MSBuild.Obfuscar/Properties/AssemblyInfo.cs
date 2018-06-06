using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Resources;

[assembly: AssemblyTitle("MSBuild.Obfuscar")]
[assembly: AssemblyDescription("MSBuild targets for Obfuscar")]
#if DEBUG
[assembly: AssemblyConfiguration("DEBUG")]
#else
[assembly: AssemblyConfiguration("RELEASE")]
#endif
[assembly: AssemblyCompany("LeXtudio")]
[assembly: AssemblyProduct("MSBuild.Obfuscar")]
[assembly: AssemblyCopyright("Copyright (C) LeXtudio 2015")]
[assembly: AssemblyVersion("2.2.11.*")]
[assembly: AssemblyFileVersion("2.2.11.0")]
[assembly: NeutralResourcesLanguage("en")]