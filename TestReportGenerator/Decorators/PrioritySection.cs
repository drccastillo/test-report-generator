using System.Text;
using TestReportGenerator.Analysis;

namespace TestReportGenerator.Decorators
{
    public class PrioritySection : IReportSection
    {
        public void AppendSection(TestAnalysisResult analysisResult, StringBuilder builder)
        {
            builder.AppendLine("\nBy Priority:");
            foreach (var priority in analysisResult.PriorityResults)
            {
                builder.AppendLine($"- {priority.Priority}: {priority.Passed}/{priority.Total} tests passed");
            }
        }
    }
}