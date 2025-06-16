using TestReportGenerator.Analysis;
using TestReportGenerator.Decorators;
using TestReportGenerator.Models;
using TestReportGenerator.Reports.Builders;
using Xunit;

namespace TestReportGenerator.Tests.Reports
{
    public class ReportBuilderTests
    {
        [Fact]
        public void Build_IncludesAllSections()
        {
            var analysis = new TestAnalysisResult
            {
                TotalTests = 1,
                PassedTests = 1,
                FailedTestsCount = 0,
                TotalDuration = 1.0,
                PassRate = 100,
                CategoryResults = new[] { new CategoryAnalysisResult { Category = "C", Total = 1, Passed = 1, PassRate = 100 } },
                PriorityResults = new[] { new PriorityAnalysisResult { Priority = "P", Total = 1, Passed = 1 } },
                FailedTestResults = new ITestResult[0]
            };

            var builder = new ReportBuilder()
                .AddSection(new SummarySection())
                .AddSection(new CategorySection())
                .AddSection(new FailedTestsSection())
                .AddSection(new PrioritySection());

            var report = builder.Build(analysis);
            Assert.Contains("TEST EXECUTION REPORT", report);
            Assert.Contains("By Category", report);
            Assert.DoesNotContain("Failed Tests:", report);
            Assert.Contains("By Priority", report);
        }
    }
}