using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using TestReportGenerator.Models;
using TestReportGenerator.Services;

namespace TestReportGenerator.Parsers
{
    public class XmlParser : ITestResultParser
    {
        private readonly IFileReader _fileReader;

        public XmlParser(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public IEnumerable<ITestResult> Parse(string path)
        {
            var content = _fileReader.ReadAllText(path);
            var xmlDoc = XDocument.Parse(content);
            var tests = xmlDoc.Descendants("test");
            var results = new List<ITestResult>();

            foreach (var element in tests)
            {
                if (!Enum.TryParse<TestStatus>(element.Element("status")?.Value, true, out var status))
                {
                    status = TestStatus.Unknown;
                }

                var durationValue = element.Element("duration")?.Value;
                var duration = double.TryParse(durationValue, out var d) ? d : 0;

                var result = new TestResult
                {
                    TestName = element.Element("testName")?.Value ?? string.Empty,
                    Status = status,
                    Duration = duration,
                    Category = element.Element("category")?.Value ?? string.Empty,
                    Priority = element.Element("priority")?.Value ?? string.Empty
                };
                results.Add(result);
            }

            return results;
        }
    }
}