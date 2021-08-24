using System;

namespace MSBuild.Obfuscar.Tests.ClickOnce {
    class Program {
        static void Main(string[] args) {
            var C = new PublicClass();
            C.DoTest();
        }
    }
}
