using System;
using System.Collections.Generic;
using Moq;
using TestReportGenerator.Facades;
using TestReportGenerator.Models;
using TestReportGenerator.Services;
using TestReportGenerator.Factories;
using TestReportGenerator.Parsers;
using TestReportGenerator.Reports;
using Xunit;

namespace TestReportGenerator.Tests.Facades
{
    public class TestReportFacadeTests
    {
        [Fact]
        public void GenerateReport_ThrowsException_WhenFileNotExists()
        {
            var fr = new Mock<IFileReader>();
            fr.Setup(f => f.Exists("path")).Returns(false);
            var factory = new Mock<IParserFactory>();
            var generator = new Mock<IReportGenerator>();
            var facade = new TestReportFacade(fr.Object, factory.Object, generator.Object);

            Assert.Throws<ArgumentException>(() => facade.GenerateReport("path"));
        }

        [Fact]
        public void GenerateReport_CallsParserAndGenerator_WhenFileExists()
        {
            var fr = new Mock<IFileReader>();
            fr.Setup(f => f.Exists("path")).Returns(true);

            var parser = new Mock<ITestResultParser>();
            parser.Setup(p => p.Parse("path")).Returns(new List<ITestResult>());

            var factory = new Mock<IParserFactory>();
            factory.Setup(f => f.GetParser("path")).Returns(parser.Object);

            var generator = new Mock<IReportGenerator>();

            var facade = new TestReportFacade(fr.Object, factory.Object, generator.Object);
            facade.GenerateReport("path");

            parser.Verify(p => p.Parse("path"), Times.Once);
            generator.Verify(g => g.GenerateReport(It.IsAny<IEnumerable<ITestResult>>()), Times.Once);
        }
    }
}