namespace TestReportGenerator.Analysis
{
    public class CategoryAnalysisResult
    {
        public string Category { get; set; } = string.Empty;
        public int Total { get; set; }
        public int Passed { get; set; }
        public double PassRate { get; set; }
    }
}