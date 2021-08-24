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
                ObfuscatorConfigFullPath = This.ObfuscatorConfigFullPath,
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
                {ObfuscateVariableNames.ObfuscatorConfigFullPath, This.ObfuscatorConfigFullPath},
                {ObfuscateVariableNames.InPath, This.InPath },
                {ObfuscateVariableNames.Module, This.Module },
                {ObfuscateVariableNames.Obfuscator, This.Obfuscator },
                {ObfuscateVariableNames.OutPath, This.OutPath },
                {ObfuscateVariableNames.OutPathConfig, This.OutPathConfig },
                {ObfuscateVariableNames.ProjectDir, This.ProjectDir },
                {ObfuscateVariableNames.ProjectName, This.ProjectName },
                {ObfuscateVariableNames.TargetDir, This.TargetDir },
                {ObfuscateVariableNames.TargetFileName, This.TargetFileName },
            };

            return ret;
        }
    }
}
