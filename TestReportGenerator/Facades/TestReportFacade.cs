using System;
using TestReportGenerator.Factories;
using TestReportGenerator.Reports;
using TestReportGenerator.Services;

namespace TestReportGenerator.Facades
{
    public class TestReportFacade : ITestReportFacade
    {
        private readonly IFileReader _fileReader;
        private readonly IParserFactory _parserFactory;
        private readonly IReportGenerator _reportGenerator;

        public TestReportFacade(
            IFileReader fileReader,
            IParserFactory parserFactory,
            IReportGenerator reportGenerator)
        {
            _fileReader = fileReader;
            _parserFactory = parserFactory;
            _reportGenerator = reportGenerator;
        }

        public void GenerateReport(string path)
        {
            if (!_fileReader.Exists(path))
            {
                throw new ArgumentException($"File not found: {path}", nameof(path));
            }

            var parser = _parserFactory.GetParser(path);
            var results = parser.Parse(path);

            _reportGenerator.GenerateReport(results);
        }
    }
}