using Microsoft.Build.Framework;

namespace MSBuild.Obfuscar.Tasks {
    internal static class ITaskExtensions {
        public static T Initialize<T>(this T This, ITask Source) where T : ITask {
            return This.Initialize(Source.BuildEngine, Source.HostObject);
        }

            public static T Initialize<T>(this T This, IBuildEngine BuildEngine, ITaskHost TaskHost) where T: ITask {
            This.BuildEngine = BuildEngine;
            This.HostObject = TaskHost;

            return This;
        }
    }

}
