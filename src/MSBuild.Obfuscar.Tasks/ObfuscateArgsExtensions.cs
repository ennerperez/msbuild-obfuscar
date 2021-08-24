using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MSBuild.Obfuscar.Tasks {
    internal static class ObfuscateArgsExtensions {

        public static string Replace(this string This, ObfuscateArgs Args) {
            var ret = This;

            var Dictionary = Args.ToDictionary();

            foreach (var item in Dictionary) {
                var Key = $@"$${item.Key}$$";

                var Find = Regex.Escape(Key);
                var Replace = item.Value;

                ret = Regex.Replace(ret, Find, Replace, RegexOptions.IgnoreCase);
            }



            return ret;
        }

        public static ObfuscateArgs GetArgs(this Obfuscate This) {
            var InPath = This.TargetDir;
            var Module = System.IO.Path.Combine(InPath, This.TargetFileName);

            var OutPath = System.IO.Path.Combine(This.TargetDir, "obfuscated");
            var OutPathConfig = System.IO.Path.Combine(OutPath, "Obfuscar.g.xml");

            var ret = new ObfuscateArgs() {
                Obfuscator = This.Obfuscator,
                ObfuscatorConfigTemplate = This.ObfuscatorConfigTemplate,
                ProjectDir = This.ProjectDir,
                ProjectName = This.ProjectName,
                TargetDir = This.TargetDir,
                TargetFileName = This.TargetFileName,

                InPath = InPath,
                Module = Module,
                OutPath = OutPath,
                OutPathConfig = OutPathConfig,
            };

            return ret;
        }

        public static IDictionary<string, string> ToDictionary(this ObfuscateArgs This) {
            var ret = new Dictionary<string, string>() {
                {ObfuscateArgNames.Default.ObfuscatorConfigTemplate, This.ObfuscatorConfigTemplate},
                {ObfuscateArgNames.Default.InPath, This.InPath },
                {ObfuscateArgNames.Default.Module, This.Module },
                {ObfuscateArgNames.Default.Obfuscator, This.Obfuscator },
                {ObfuscateArgNames.Default.OutPath, This.OutPath },
                {ObfuscateArgNames.Default.OutPathConfig, This.OutPathConfig },
                {ObfuscateArgNames.Default.ProjectDir, This.ProjectDir },
                {ObfuscateArgNames.Default.ProjectName, This.ProjectName },
                {ObfuscateArgNames.Default.TargetDir, This.TargetDir },
                {ObfuscateArgNames.Default.TargetFileName, This.TargetFileName },
            };

            return ret;
        }
    }
}
