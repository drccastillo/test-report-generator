using System.Collections.Generic;
using TestReportGenerator.Models;

namespace TestReportGenerator.Parsers
{
    public interface ITestResultParser
    {
        IEnumerable<ITestResult> Parse(string path);
    }
}