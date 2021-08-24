using Microsoft.Build.Framework;
using Microsoft.Build.Tasks;
using Microsoft.Build.Utilities;
using MSBuild.Obfuscar;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace MSBuild.Obfuscar.Tasks {

    public class Obfuscate : Microsoft.Build.Utilities.Task {

        public string Obfuscator { get; set; } = string.Empty;
        public string ObfuscatorConfigTemplate { get; set; } = string.Empty;

        public string ProjectDir { get; set; } = string.Empty;
        public string ProjectName { get; set; } = string.Empty;
        public string TargetDir { get; set; } = string.Empty;
        public string TargetFileName { get; set; } = string.Empty;



        public override bool Execute() {

            var Args = this.GetArgs();

            Log.LogMessage(MessageImportance.High, $@"Obfuscate - v{InternalAssemblyInfo.AssemblyVersion} @ {InternalAssemblyInfo.AssemblyBuildDate}");
            Log.LogMessage(MessageImportance.High, $@"-----------");
            Log.LogMessage(MessageImportance.High, $@"Obfuscator               = {Args.Obfuscator}");
            Log.LogMessage(MessageImportance.High, $@"ObfuscatorConfigTemplate = {Args.ObfuscatorConfigTemplate}");
            Log.LogMessage(MessageImportance.High, $@"ProjectDir               = {Args.ProjectDir}");
            Log.LogMessage(MessageImportance.High, $@"TargetDir                = {Args.TargetDir}");
            Log.LogMessage(MessageImportance.High, $@"TargetFileName           = {Args.TargetFileName}");



            var ConfigTemplate = Resources.Defaults.ResourcePackage.Obfuscar;
            if (System.IO.File.Exists(ObfuscatorConfigTemplate)) {
                ConfigTemplate = System.IO.File.ReadAllText(ObfuscatorConfigTemplate)
                ;
            } else {
                Log.LogMessage(MessageImportance.High, $@"Path to {ObfuscateArgNames.Default.ObfuscatorConfigTemplate} does not exist.  Using a default template.");
            }

            var Config = ConfigTemplate.Replace(Args);

            Log.LogMessage(MessageImportance.High, $@"Creating {Args.OutPathConfig}:");
            Log.LogMessage(MessageImportance.High, $@"FROM TEMPLATE:");
            Log.LogMessage(MessageImportance.High, ConfigTemplate);
            Log.LogMessage(MessageImportance.High, $@"NEW CONTENT:");
            Log.LogMessage(MessageImportance.High, Config);

            var CreateDirectoryResult = new MakeDir() {
                Directories = Args.OutPath.ToTaskList(),
            }.Initialize(this).Execute();

            System.IO.File.WriteAllText(Args.OutPathConfig, Config);

            var ExecTask = new Exec() {
                Command = $@"""{Args.Obfuscator}"" ""{Args.OutPathConfig}""",
            }.Initialize(this);
            var ExecResult = ExecTask.Execute();


            var FilesToMoveTask = new CreateItem() {
                Include = $@"{Args.OutPath}\*.*".ToTaskList(),
            }.Initialize(this);
            var FilesToMoveResult = FilesToMoveTask.Execute();
            var FilesToMove = FilesToMoveTask.Include;


            var MoveResult = new Move() {
                SourceFiles = FilesToMove,
                DestinationFolder = Args.InPath.ToTaskItem(),
                OverwriteReadOnlyFiles = true,
            }.Initialize(this).Execute();
            /*
            var DeleteDirectoryResult = new RemoveDir() {
                Directories = Args.OutPath.ToTaskList()
            }.Initialize(this).Execute();
            */

            

            return true;
        }
    }
}
