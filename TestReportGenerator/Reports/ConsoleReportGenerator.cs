using System;
using System.Collections.Generic;
using TestReportGenerator.Analysis;
using TestReportGenerator.Decorators;
using TestReportGenerator.Models;
using TestReportGenerator.Reports.Builders;

namespace TestReportGenerator.Reports
{
    public class ConsoleReportGenerator : BaseReportGenerator
    {
        private readonly ITestAnalyzer _analyzer;
        private readonly ReportBuilder _builder;

        public ConsoleReportGenerator(ITestAnalyzer analyzer, ReportBuilder builder)
        {
            _analyzer = analyzer;
            _builder = builder;
            ConfigureBuilder();
        }

        private void ConfigureBuilder()
        {
            _builder
                .AddSection(new SummarySection())
                .AddSection(new CategorySection())
                .AddSection(new FailedTestsSection())
                .AddSection(new PrioritySection());
        }

        protected override void WriteHeader()
        {
            Console.WriteLine();
        }

        protected override void WriteContent(IEnumerable<ITestResult> results)
        {
            var analysisResult = _analyzer.Analyze(results);
            var report = _builder.Build(analysisResult);
            Console.WriteLine(report);
        }

        protected override void WriteFooter()
        {
            Console.WriteLine();
        }
    }
}