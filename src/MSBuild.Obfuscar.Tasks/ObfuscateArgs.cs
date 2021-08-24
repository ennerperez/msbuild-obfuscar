namespace MSBuild.Obfuscar.Tasks {
    internal class ObfuscateArgs {
        public string Obfuscator { get; set; }
        public string ObfuscatorConfigFullPath { get; set; }
        public string ProjectDir { get; set; }
        public string ProjectName { get; set; }
        public string TargetDir { get; set; }
        public string TargetFileName { get; set; }

        public string InPath { get; set; }
        public string OutPath { get; set; }
        public string OutPathConfig { get; set; }
        public string Module { get; set; }
    }
}
