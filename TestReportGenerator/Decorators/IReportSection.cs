using System.Text;
using TestReportGenerator.Analysis;

namespace TestReportGenerator.Decorators
{
    public interface IReportSection
    {
        void AppendSection(TestAnalysisResult analysisResult, StringBuilder builder);
    }
}