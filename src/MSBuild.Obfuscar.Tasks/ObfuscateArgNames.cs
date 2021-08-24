namespace MSBuild.Obfuscar.Tasks {
    internal class ObfuscateArgNames {
        public static ObfuscateArgNames Default { get; } = new();

        //These are intentially not implemented using nameof() because a refactor would not be future-proof
        public string Obfuscator { get; } = "Obfuscator";
        public string ObfuscatorConfigTemplate { get; } = "ObfuscatorConfigTemplate";
        public string ObfuscatorConfigTemplate_ProjectReferences_Append { get; } = "ObfuscatorConfigTemplate_ProjectReferences_Append";

        public string SolutionDir { get; } = "SolutionDir";
        public string SolutionFileName { get; } = "SolutionFileName";
        public string SolutionName { get; } = "SolutionName";

        public string ProjectDir { get; } = "ProjectDir";
        public string ProjectFileName { get; } = "ProjectFileName";
        public string ProjectName { get; } = "ProjectName";

        public string TargetDir { get; } = "TargetDir";
        public string TargetName { get; } = "TargetName";
        public string TargetFileName { get; } = "TargetFileName";

        public string ObfuscatedDir { get; } = "ObfuscatedDir";

        public string InPath { get; } = "InPath";
        public string OutPath { get; } = "OutPath";
        public string OutPathConfig { get; } = "OutPathConfig";

        public string Module { get; } = "Module";
    }
    
}
