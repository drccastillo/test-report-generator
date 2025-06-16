using System.Linq;
using System.Text;
using TestReportGenerator.Analysis;

namespace TestReportGenerator.Decorators
{
    public class FailedTestsSection : IReportSection
    {
        public void AppendSection(TestAnalysisResult analysisResult, StringBuilder builder)
        {
            if (!analysisResult.FailedTestResults.Any())
            {
                return;
            }

            builder.AppendLine("\nFailed Tests:");
            foreach (var test in analysisResult.FailedTestResults)
            {
                builder.AppendLine($"- {test.TestName} ({test.Duration}s) - {test.Category}");
            }
        }
    }
}