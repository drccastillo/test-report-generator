using System.Text;
using TestReportGenerator.Analysis;

namespace TestReportGenerator.Decorators
{
    public class SummarySection : IReportSection
    {
        public void AppendSection(TestAnalysisResult analysisResult, StringBuilder builder)
        {
            builder.AppendLine("==========================================");
            builder.AppendLine("             TEST EXECUTION REPORT        ");
            builder.AppendLine($"Total Tests: {analysisResult.TotalTests}");
            builder.AppendLine($"✅ Passed: {analysisResult.PassedTests} ({analysisResult.PassRate:F2}%)");
            builder.AppendLine($"❌ Failed: {analysisResult.FailedTestsCount} ({100 - analysisResult.PassRate:F2}%)");
            builder.AppendLine($"Total Duration: {analysisResult.TotalDuration:F2} seconds");
            builder.AppendLine("==========================================");
        }
    }
}