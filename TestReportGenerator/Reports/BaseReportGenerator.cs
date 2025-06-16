using System.Collections.Generic;
using TestReportGenerator.Models;

namespace TestReportGenerator.Reports
{
    public abstract class BaseReportGenerator : IReportGenerator
    {
        public void GenerateReport(IEnumerable<ITestResult> results)
        {
            WriteHeader();
            WriteContent(results);
            WriteFooter();
        }

        protected abstract void WriteHeader();
        protected abstract void WriteContent(IEnumerable<ITestResult> results);
        protected abstract void WriteFooter();
    }
}