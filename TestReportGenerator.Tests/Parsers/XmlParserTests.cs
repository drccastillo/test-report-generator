using System.Collections.Generic;
using Moq;
using TestReportGenerator.Models;
using TestReportGenerator.Parsers;
using TestReportGenerator.Services;
using Xunit;

namespace TestReportGenerator.Tests.Parsers
{
    public class XmlParserTests
    {
        [Fact]
        public void Parse_ReturnsEmpty_WhenNoTests()
        {
            var xml = "<tests></tests>";
            var mock = new Mock<IFileReader>();
            mock.Setup(f => f.ReadAllText(It.IsAny<string>())).Returns(xml);
            var parser = new XmlParser(mock.Object);
            Assert.Empty(parser.Parse("file.xml"));
        }

        [Fact]
        public void Parse_ReturnsResults_ForValidXml()
        {
            var xml = "<tests><test><testName>T1</testName><status>PASSED</status><duration>1.5</duration><category>C</category><priority>P</priority></test></tests>";
            var mock = new Mock<IFileReader>();
            mock.Setup(f => f.ReadAllText(It.IsAny<string>())).Returns(xml);
            var parser = new XmlParser(mock.Object);
            var list = new List<ITestResult>(parser.Parse("file.xml"));
            Assert.Single(list);
            Assert.Equal(TestStatus.Passed, list[0].Status);
        }
    }
}