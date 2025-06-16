using System.Collections.Generic;
using TestReportGenerator.Models;

namespace TestReportGenerator.Analysis
{
    public interface ITestAnalyzer
    {
        TestAnalysisResult Analyze(IEnumerable<ITestResult> results);
    }
}