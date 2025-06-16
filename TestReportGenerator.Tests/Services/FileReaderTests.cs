using System.IO;
using TestReportGenerator.Services;
using Xunit;

namespace TestReportGenerator.Tests.Services
{
    public class FileReaderTests
    {
        private readonly FileReader _fileReader = new();

        [Fact]
        public void Exists_ReturnsFalse_ForNonexistentFile()
        {
            Assert.False(_fileReader.Exists("__nonexistent__"));
        }

        [Fact]
        public void ReadAllText_ReturnsCorrectContent()
        {
            var temp = Path.GetTempFileName();
            File.WriteAllText(temp, "hello");
            Assert.Equal("hello", _fileReader.ReadAllText(temp));
            File.Delete(temp);
        }

        [Fact]
        public void ReadAllLines_ReturnsCorrectLines()
        {
            var temp = Path.GetTempFileName();
            File.WriteAllLines(temp, new[] { "a", "b" });
            Assert.Equal(new[] { "a", "b" }, _fileReader.ReadAllLines(temp));
            File.Delete(temp);
        }
    }
}