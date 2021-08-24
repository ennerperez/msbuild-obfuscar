namespace MSBuild.Obfuscar.Tasks {
    internal partial class ObfuscateArgs {
        public string Obfuscator { get; set; } = string.Empty;
        public string ObfuscatorConfigTemplate { get; set; } = string.Empty;
        public string ProjectDir { get; set; } = string.Empty;
        public string ProjectName { get; set; } = string.Empty;
        public string TargetDir { get; set; } = string.Empty;
        public string TargetFileName { get; set; } = string.Empty;

        public string InPath { get; set; } = string.Empty;
        public string OutPath { get; set; } = string.Empty;
        public string OutPathConfig { get; set; } = string.Empty;
        public string Module { get; set; } = string.Empty;
    }
}
