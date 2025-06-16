namespace TestReportGenerator.Models
{
    public class TestResult : ITestResult
    {
        public string TestName { get; set; } = string.Empty;
        public TestStatus Status { get; set; }
        public double Duration { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
    }
}
