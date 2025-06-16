using System.Collections.Generic;
using Moq;
using TestReportGenerator.Models;
using TestReportGenerator.Parsers;
using TestReportGenerator.Services;
using Xunit;

namespace TestReportGenerator.Tests.Parsers
{
    public class JsonParserTests
    {
        [Fact]
        public void Parse_ReturnsEmpty_WhenNoTests()
        {
            var json = "{\"tests\": []}";
            var mock = new Mock<IFileReader>();
            mock.Setup(f => f.ReadAllText(It.IsAny<string>())).Returns(json);
            var parser = new JsonParser(mock.Object);
            Assert.Empty(parser.Parse("file.json"));
        }

        [Fact]
        public void Parse_ReturnsResults_ForValidJson()
        {
            var json = "{\"tests\":[{\"testName\":\"T1\",\"status\":\"PASSED\",\"duration\":1.5,\"category\":\"C\",\"priority\":\"P\"}]}";
            var mock = new Mock<IFileReader>();
            mock.Setup(f => f.ReadAllText(It.IsAny<string>())).Returns(json);
            var parser = new JsonParser(mock.Object);
            var list = new List<ITestResult>(parser.Parse("file.json"));
            Assert.Single(list);
            Assert.Equal(TestStatus.Passed, list[0].Status);
        }
    }
}