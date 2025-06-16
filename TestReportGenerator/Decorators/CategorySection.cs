using System.Text;
using TestReportGenerator.Analysis;

namespace TestReportGenerator.Decorators
{
    public class CategorySection : IReportSection
    {
        public void AppendSection(TestAnalysisResult analysisResult, StringBuilder builder)
        {
            builder.AppendLine("\nBy Category:");
            foreach (var category in analysisResult.CategoryResults)
            {
                builder.AppendLine($"- {category.Category}: {category.Passed}/{category.Total} passed ({category.PassRate:F2}%)");
            }
        }
    }
}