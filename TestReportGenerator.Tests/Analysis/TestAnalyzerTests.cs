using System.Collections.Generic;
using TestReportGenerator.Analysis;
using TestReportGenerator.Models;
using Xunit;

namespace TestReportGenerator.Tests.Analysis
{
    public class TestAnalyzerTests
    {
        [Fact]
        public void Analyze_ReturnsCorrectMetrics()
        {
            var results = new List<ITestResult>
            {
                new TestResult { TestName = "T1", Status = TestStatus.Passed, Duration = 1.0, Category = "C1", Priority = "P1" },
                new TestResult { TestName = "T2", Status = TestStatus.Failed, Duration = 2.0, Category = "C1", Priority = "P2" },
                new TestResult { TestName = "T3", Status = TestStatus.Passed, Duration = 3.0, Category = "C2", Priority = "P1" }
            };

            var analyzer = new TestAnalyzer();
            var analysis = analyzer.Analyze(results);

            Assert.Equal(3, analysis.TotalTests);
            Assert.Equal(2, analysis.PassedTests);
            Assert.Equal(1, analysis.FailedTestsCount);
            Assert.Equal(6.0, analysis.TotalDuration);
            Assert.Equal(66.66666666666666, analysis.PassRate, 1);

            Assert.Collection(analysis.CategoryResults,
                c => { Assert.Equal("C1", c.Category); Assert.Equal(2, c.Total); Assert.Equal(1, c.Passed); },
                c => { Assert.Equal("C2", c.Category); Assert.Equal(1, c.Total); Assert.Equal(1, c.Passed); });

            Assert.Collection(analysis.PriorityResults,
                p => { Assert.Equal("P1", p.Priority); Assert.Equal(2, p.Total); Assert.Equal(2, p.Passed); },
                p => { Assert.Equal("P2", p.Priority); Assert.Equal(1, p.Total); Assert.Equal(0, p.Passed); });

            Assert.Single(analysis.FailedTestResults);
        }
    }
}