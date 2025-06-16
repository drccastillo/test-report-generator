using System.Collections.Generic;
using TestReportGenerator.Models;

namespace TestReportGenerator.Reports
{
    public interface IReportGenerator
    {
        void GenerateReport(IEnumerable<ITestResult> results);
    }
}