using System.IO;

namespace TestReportGenerator.Services
{
    public class FileReader : IFileReader
    {
        public bool Exists(string path) => File.Exists(path);
        public string ReadAllText(string path) => File.ReadAllText(path);
        public string[] ReadAllLines(string path) => File.ReadAllLines(path);
    }
}