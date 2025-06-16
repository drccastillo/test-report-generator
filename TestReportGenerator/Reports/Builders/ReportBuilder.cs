using System.Collections.Generic;
using System.Text;
using TestReportGenerator.Analysis;
using TestReportGenerator.Decorators;

namespace TestReportGenerator.Reports.Builders
{
    public class ReportBuilder
    {
        private readonly List<IReportSection> _sections = new List<IReportSection>();

        public ReportBuilder AddSection(IReportSection section)
        {
            _sections.Add(section);
            return this;
        }

        public string Build(TestAnalysisResult analysisResult)
        {
            var builder = new StringBuilder();
            foreach (var section in _sections)
            {
                section.AppendSection(analysisResult, builder);
            }
            return builder.ToString();
        }
    }
}