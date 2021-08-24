using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSBuild.Obfuscar.Tasks {

    internal static class ITaskItemExtensions {
        public static ITaskItem[] ToTaskList(this string This) {
            return new[] { This }.ToTaskList();
        }


        public static ITaskItem[] ToTaskList(this IEnumerable<string> This) {
            var ret = This.Select(x => ToTaskItem(x)).ToArray();

            return ret;
        }

        public static ITaskItem ToTaskItem(this string This) {
            var ret = new TaskItem(This);

            return ret;
        }

    }

}
