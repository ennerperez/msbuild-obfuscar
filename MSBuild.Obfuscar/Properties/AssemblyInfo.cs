﻿using System.Reflection;
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
[assembly: AssemblyCompany("Enner Pérez")]
[assembly: AssemblyProduct("MSBuild.Obfuscar")]
[assembly: AssemblyCopyright("Copyright (C) 2021")]
[assembly: AssemblyVersion("2.2.29")]
[assembly: AssemblyFileVersion("2.2.29")]
[assembly: NeutralResourcesLanguage("en")]