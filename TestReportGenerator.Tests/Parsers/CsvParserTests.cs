using System.Collections.Generic;
using Moq;
using TestReportGenerator.Models;
using TestReportGenerator.Parsers;
using TestReportGenerator.Services;
using Xunit;

namespace TestReportGenerator.Tests.Parsers
{
    public class CsvParserTests
    {
        [Fact]
        public void Parse_ReturnsEmpty_WhenNoData()
        {
            var mock = new Mock<IFileReader>();
            mock.Setup(f => f.ReadAllLines(It.IsAny<string>())).Returns(new string[0]);
            var parser = new CsvParser(mock.Object);
            Assert.Empty(parser.Parse("file.csv"));
        }

        [Fact]
        public void Parse_ReturnsResults_ForValidCsv()
        {
            var lines = new[]
            {
                "Name,Status,Duration,Category,Priority",
                "T1,PASSED,1.5,Cat,High",
                "T2,FAILED,2.0,Cat,Low"
            };
            var mock = new Mock<IFileReader>();
            mock.Setup(f => f.ReadAllLines("file.csv")).Returns(lines);
            var parser = new CsvParser(mock.Object);
            var list = new List<ITestResult>(parser.Parse("file.csv"));
            Assert.Equal(2, list.Count);
            Assert.Equal(TestStatus.Passed, list[0].Status);
            Assert.Equal(TestStatus.Failed, list[1].Status);
        }
    }
}