using System.Reflection;
using System.Resources;

[assembly: AssemblyTitle("MSBuild.Obfuscar")]
[assembly: AssemblyDescription("MSBuild targets for Obfuscar")]
#if DEBUG
[assembly: AssemblyConfiguration("DEBUG")]
#else
[assembly: AssemblyConfiguration("RELEASE")]
#endif
[assembly: AssemblyCompany("Enner Pérez")]
[assembly: AssemblyProduct("MSBuild.Obfuscar")]
[assembly: AssemblyCopyright("Copyright (C) 2021")]
[assembly: AssemblyVersion("2.2.30.0")]
[assembly: AssemblyFileVersion("2.2.30.0")]
[assembly: NeutralResourcesLanguage("en")]