using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace MSBuild.Obfuscar.Tasks {
    internal static class ObfuscateArgsExtensions {

        private static string GetArgName(string Input) {
            var ret = $@"{{{{{Input}}}}}";

            return ret;
        }

        public static string Replace(this string This, ObfuscateArgs Args) {
            var ret = This;

            var Dictionary = Args.GetExportableArgs();

            foreach (var item in Dictionary) {
                var ArgName = GetArgName(item.Key);

                var Find = Regex.Escape(ArgName);
                var Replace = item.Value;

                ret = Regex.Replace(ret, Find, Replace, RegexOptions.IgnoreCase);
            }

            if (Args.ObfuscatorConfigTemplate_ProjectReferences_Append) {
                var Doc = XDocument.Parse(ret);
                var Root = Doc.Root;

                foreach (var item in Args.ProjectReferencedFolders) {
                    var Node = new XElement("AssemblySearchPath");
                    var Attribute1 = new XAttribute("path", item);
                    Node.Add(Attribute1);

                    Root.Add(Node);
                }

                ret = Doc.ToString();

            }



            return ret;
        }

        public static ObfuscateArgs GetArgs(this Obfuscate This) {
            var InPath = This.TargetDir;
            var Module = System.IO.Path.Combine(InPath, This.TargetFileName);

            var RandomNumber = DateTime.Now.Ticks;

            var OutPath = System.IO.Path.Combine(This.TargetDir, $@"obfuscated_{RandomNumber}");
            var OutPathConfig = System.IO.Path.Combine(OutPath, $@"Obfuscar.g.xml");

            var ProjectReferencedFiles = new List<string>();
            {
                foreach (var item in This.ProjectReferences) {
                    var ItemName = item.ItemSpec;
                    if (System.IO.File.Exists(ItemName)) {
                        ProjectReferencedFiles.Add(ItemName);
                    }
                }
                ProjectReferencedFiles = ProjectReferencedFiles.Distinct().ToList();
            }

            var ProjectReferencedFolders = new List<string>();
            {
                foreach (var item in This.ProjectReferences) {
                    var ItemName = System.IO.Path.GetDirectoryName(item.ItemSpec);
                    if (System.IO.Directory.Exists(ItemName)) {
                        ProjectReferencedFolders.Add(ItemName);
                    }
                }
                ProjectReferencedFolders = ProjectReferencedFolders.Distinct().ToList();
            }

            var ret = new ObfuscateArgs() {
                Obfuscator = This.Obfuscator,
                ObfuscatorConfigTemplate = This.ObfuscatorConfigTemplate,
                ObfuscatorConfigTemplate_ProjectReferences_Append = This.ObfuscatorConfigTemplate_ProjectReferences_Append,

                SolutionDir = This.SolutionDir,
                SolutionFileName = This.SolutionFileName,
                SolutionName = This.SolutionName,

                ProjectDir = This.ProjectDir,
                ProjectFileName = This.ProjectFileName,
                ProjectName = This.ProjectName,

                TargetDir = This.TargetDir,
                TargetFileName = This.TargetFileName,
                TargetName = This.TargetName,

                InPath = InPath,
                Module = Module,
                OutPath = OutPath,
                OutPathConfig = OutPathConfig,

                ProjectReferencedFiles = ProjectReferencedFiles,
                ProjectReferencedFolders = ProjectReferencedFolders,
            };

            return ret;
        }

        public static IDictionary<string, string> GetExportableArgs(this ObfuscateArgs This) {
            var ret = new Dictionary<string, string>() {
                {ObfuscateArgNames.Default.Obfuscator, This.Obfuscator },
                {ObfuscateArgNames.Default.ObfuscatorConfigTemplate, This.ObfuscatorConfigTemplate},
                {ObfuscateArgNames.Default.ObfuscatorConfigTemplate_ProjectReferences_Append, This.ObfuscatorConfigTemplate_ProjectReferences_Append.ToString()},

                {ObfuscateArgNames.Default.InPath, This.InPath },
                {ObfuscateArgNames.Default.Module, This.Module },
                
                {ObfuscateArgNames.Default.OutPath, This.OutPath },
                {ObfuscateArgNames.Default.OutPathConfig, This.OutPathConfig },
                
                {ObfuscateArgNames.Default.SolutionDir, This.SolutionDir },
                {ObfuscateArgNames.Default.SolutionFileName, This.SolutionFileName },
                {ObfuscateArgNames.Default.SolutionName, This.SolutionName },
                
                {ObfuscateArgNames.Default.ProjectDir, This.ProjectDir },
                {ObfuscateArgNames.Default.ProjectFileName, This.ProjectFileName },
                {ObfuscateArgNames.Default.ProjectName, This.ProjectName },
                
                {ObfuscateArgNames.Default.TargetDir, This.TargetDir },
                {ObfuscateArgNames.Default.TargetFileName, This.TargetFileName },
                {ObfuscateArgNames.Default.TargetName, This.TargetName },
            };

            return ret;
        }
    }
}
