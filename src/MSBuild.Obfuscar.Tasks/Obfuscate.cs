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
        
        public string Obfuscator { get; set; }
        public string ObfuscatorConfigFullPath { get; set; }

        public string ProjectDir { get; set; }
        public string ProjectName { get; set; }
        public string TargetDir { get; set; }
        public string TargetFileName { get; set; }



        public override bool Execute() {

            var Args = this.GetArgs();

            Log.LogMessage(MessageImportance.High, $@"Obfuscator               = {Args.Obfuscator}");
            Log.LogMessage(MessageImportance.High, $@"ObfuscatorConfigFullPath = {Args.ObfuscatorConfigFullPath}");
            Log.LogMessage(MessageImportance.High, $@"ProjectDir               = {Args.ProjectDir}");
            Log.LogMessage(MessageImportance.High, $@"TargetDir                = {Args.TargetDir}");
            Log.LogMessage(MessageImportance.High, $@"TargetFileName           = {Args.TargetFileName}");



            if (!System.IO.File.Exists(ObfuscatorConfigFullPath)) {
                Log.LogError($@"ConfigFullPath({ObfuscatorConfigFullPath}) does not exist");
                return false;
            }

            Log.LogMessage(MessageImportance.High, $@"Replacing variables in ObfuscatorConfigFullPath...");

            var OutPathConfigConfig = System.IO.File.ReadAllText(ObfuscatorConfigFullPath)
                .Replace(Args)
                ;
            Log.LogMessage("New ConfigFullPath:");
            Log.LogMessage(OutPathConfigConfig);


            var CreateDirectoryResult = new MakeDir() {
                Directories = Args.OutPath.ToTaskList(),
            }.Initialize(this).Execute();

            System.IO.File.WriteAllText(Args.OutPathConfig, OutPathConfigConfig);

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
