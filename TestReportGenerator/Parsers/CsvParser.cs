using System;
using System.Collections.Generic;
using System.Linq;
using TestReportGenerator.Models;
using TestReportGenerator.Services;

namespace TestReportGenerator.Parsers
{
    public class CsvParser : ITestResultParser
    {
        private readonly IFileReader _fileReader;

        public CsvParser(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public IEnumerable<ITestResult> Parse(string path)
        {
            var lines = _fileReader.ReadAllLines(path);
            if (lines.Length < 2)
            {
                return Enumerable.Empty<ITestResult>();
            }

            var results = new List<ITestResult>();
            for (int i = 1; i < lines.Length; i++)
            {
                var parts = lines[i].Split(',', StringSplitOptions.None);
                if (parts.Length >= 5)
                {
                    if (!Enum.TryParse<TestStatus>(parts[1], true, out var status))
                    {
                        status = TestStatus.Unknown;
                    }

                    if (!double.TryParse(parts[2], out var duration))
                    {
                        duration = 0;
                    }

                    var result = new TestResult
                    {
                        TestName = parts[0],
                        Status = status,
                        Duration = duration,
                        Category = parts[3],
                        Priority = parts[4]
                    };
                    results.Add(result);
                }
            }

            return results;
        }
    }
}