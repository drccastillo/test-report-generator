using System.Collections.Generic;
using TestReportGenerator.Models;

namespace TestReportGenerator.Analysis
{
    public class TestAnalysisResult
    {
        public int TotalTests { get; set; }
        public int PassedTests { get; set; }
        public int FailedTestsCount { get; set; }
        public double TotalDuration { get; set; }
        public double PassRate { get; set; }
        public IEnumerable<CategoryAnalysisResult> CategoryResults { get; set; } = new List<CategoryAnalysisResult>();
        public IEnumerable<PriorityAnalysisResult> PriorityResults { get; set; } = new List<PriorityAnalysisResult>();
        public IEnumerable<ITestResult> FailedTestResults { get; set; } = new List<ITestResult>();
    }
}