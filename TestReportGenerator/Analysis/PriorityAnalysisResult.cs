namespace TestReportGenerator.Analysis
{
    public class PriorityAnalysisResult
    {
        public string Priority { get; set; } = string.Empty;
        public int Total { get; set; }
        public int Passed { get; set; }
    }
}