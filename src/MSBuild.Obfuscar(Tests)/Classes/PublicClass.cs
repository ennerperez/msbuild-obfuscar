using System;

namespace MSBuild.Obfuscar.Tests {
    public class PublicClass {
        public void DoTest() {
            DoTestInternal();
        }

        private void DoTestInternal() {
            var V1 = new InternalClass();
            V1.DoTestInternal();
        }

    }

}
