using System.Collections.Generic;
using System.Linq;
using TestReportGenerator.Models;

namespace TestReportGenerator.Analysis
{
    public class TestAnalyzer : ITestAnalyzer
    {
        public TestAnalysisResult Analyze(IEnumerable<ITestResult> results)
        {
            var list = results.ToList();
            var total = list.Count;
            var passed = list.Count(r => r.Status == TestStatus.Passed);
            var failed = list.Count(r => r.Status == TestStatus.Failed);
            var duration = list.Sum(r => r.Duration);
            var passRate = total > 0 ? (double)passed / total * 100 : 0;

            var categoryResults = list
                .GroupBy(r => r.Category)
                .Select(g => new CategoryAnalysisResult
                {
                    Category = g.Key,
                    Total = g.Count(),
                    Passed = g.Count(r => r.Status == TestStatus.Passed),
                    PassRate = g.Count() > 0 ? (double)g.Count(r => r.Status == TestStatus.Passed) / g.Count() * 100 : 0
                })
                .ToList();

            var priorityResults = list
                .GroupBy(r => r.Priority)
                .Select(g => new PriorityAnalysisResult
                {
                    Priority = g.Key,
                    Total = g.Count(),
                    Passed = g.Count(r => r.Status == TestStatus.Passed)
                })
                .ToList();

            var failedTests = list.Where(r => r.Status == TestStatus.Failed).ToList();

            return new TestAnalysisResult
            {
                TotalTests = total,
                PassedTests = passed,
                FailedTestsCount = failed,
                TotalDuration = duration,
                PassRate = passRate,
                CategoryResults = categoryResults,
                PriorityResults = priorityResults,
                FailedTestResults = failedTests
            };
        }
    }
}