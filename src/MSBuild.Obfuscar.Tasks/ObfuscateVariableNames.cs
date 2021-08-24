namespace MSBuild.Obfuscar.Tasks {
    internal class ObfuscateVariableNames {
        //These are intentially not implemented using nameof() because a refactor would not be future-proof
        public static string Obfuscator { get; } = "Obfuscator";
        public static string ObfuscatorConfigFullPath { get; } = "ObfuscatorConfigFullPath";
        public static string ProjectDir { get; } = "ProjectDir";
        public static string ProjectName { get; } = "ProjectName";
        public static string TargetDir { get; } = "TargetDir";
        public static string ObfuscatedDir { get; } = "ObfuscatedDir";
        public static string TargetFileName { get; } = "TargetFileName";

        public static string InPath { get; } = "InPath";
        public static string OutPath { get; } = "OutPath";
        public static string OutPathConfig { get; } = "OutPathConfig";

        public static string Module { get; } = "Module";


    }
}
