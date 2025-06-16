using System;
using System.Collections.Generic;
using System.Text.Json;
using TestReportGenerator.Models;
using TestReportGenerator.Services;

namespace TestReportGenerator.Parsers
{
    public class JsonParser : ITestResultParser
    {
        private readonly IFileReader _fileReader;

        public JsonParser(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public IEnumerable<ITestResult> Parse(string path)
        {
            var content = _fileReader.ReadAllText(path);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<TestResultsJson>(content, options);
            if (data?.Tests == null)
            {
                return Array.Empty<ITestResult>();
            }

            var results = new List<ITestResult>();
            foreach (var test in data.Tests)
            {
                if (!Enum.TryParse<TestStatus>(test.Status, true, out var status))
                {
                    status = TestStatus.Unknown;
                }

                var result = new TestResult
                {
                    TestName = test.TestName,
                    Status = status,
                    Duration = test.Duration,
                    Category = test.Category,
                    Priority = test.Priority
                };
                results.Add(result);
            }

            return results;
        }
    }
}