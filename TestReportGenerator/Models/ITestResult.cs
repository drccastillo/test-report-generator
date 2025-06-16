namespace TestReportGenerator.Models
{
    public interface ITestResult
    {
        string TestName { get; }
        TestStatus Status { get; }
        double Duration { get; }
        string Category { get; }
        string Priority { get; }
    }
}