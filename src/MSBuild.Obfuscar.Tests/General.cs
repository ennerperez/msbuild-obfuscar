using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MSBuild.Obfuscar.Tests
{
    public class Tests
    {
        [SetUp]
        public async Task Setup()
        {
            var version = Assembly.GetAssembly(GetType())?.GetName().Version?.ToString(3);
            if (!string.IsNullOrWhiteSpace(version))
            {
                var url = $"https://www.nuget.org/api/v2/package/Obfuscar/{version}";
                var dirPath = Path.Combine(Directory.GetCurrentDirectory(), "nugets");
                var filePath = Path.Combine(dirPath, $"obfuscar.{version}.nupkg");

                if (Directory.Exists(dirPath)) Directory.Delete(dirPath, true);

                if (!File.Exists(filePath))
                {
                    if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);
                    using (var client = new HttpClient())
                    {
                        var request = await client.GetAsync(url);
                        request.EnsureSuccessStatusCode();
                        var buffer = await request.Content.ReadAsStreamAsync();
                        using (var file = new FileStream(filePath, FileMode.CreateNew))
                        {
                            await buffer.CopyToAsync(file);
                        }
                    }

                    if (File.Exists(filePath))
                        System.IO.Compression.ZipFile.ExtractToDirectory(filePath, dirPath);
                    else
                        Assert.Fail();
                }
                else
                    Assert.Fail();
            }
            else
                Assert.Fail();
        }

        private void Obfuscar(string framework)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..", "Examples", framework);

            if (Directory.Exists(Path.Combine(path, "bin", "Debug", "obfuscated")))
                Directory.Delete(Path.Combine(path, "bin", "Debug", "obfuscated"), true);
            Thread.Sleep(2000);
            var process = new Process();
            process.StartInfo = new ProcessStartInfo()
            {
                WorkingDirectory = path,
                FileName = Path.Combine(Directory.GetCurrentDirectory(), "nugets", "tools", "Obfuscar.Console.exe"),
                Arguments = "Obfuscar.xml",
            };
            process.Start();
            Thread.Sleep(2000);
            if (File.Exists(Path.Combine(path, "bin", "Debug", "obfuscated", "MSBuild.Obfuscar.Example.dll")))
                Assert.Pass();
            else
                Assert.Fail();
        }


        [Test(Description = ".NET Framework 2.0")]
        public void net20()
        {
            Obfuscar("net2.0");
        }

        [Test(Description = ".NET Framework 4.0")]
        public void net40()
        {
            Obfuscar("net4.0");
        }

        [Test(Description = ".NET 5.0")]
        public void net50()
        {
            Obfuscar("net5.0");
        }

        [Test(Description = ".NET Standard 1.7")]
        public void netstandard17()
        {
            Obfuscar("netstandard1.7");
        }

        [Test(Description = ".NET Standard 2.1")]
        public void netstandard21()
        {
            Obfuscar("netstandard2.1");
        }
    }
}