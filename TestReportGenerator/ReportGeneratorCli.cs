using System;
using TestReportGenerator.Facades;

namespace TestReportGenerator
{
    public class ReportGeneratorCli
    {
        private readonly ITestReportFacade _facade;

        public ReportGeneratorCli(ITestReportFacade facade)
        {
            _facade = facade;
        }

        public void Run(string[] args)
        {
            Console.WriteLine("Test Report Generator v1.0");
            Console.WriteLine("==========================\n");

            if (args.Length == 0)
            {
                Console.WriteLine("""
Usage: TestReportGenerator <test_results_file>
Supported formats: .csv, .json, .xml

Example: TestReportGenerator test_results.csv
""");
                return;
            }

            var inputFile = args[0];

            try
            {
                _facade.GenerateReport(inputFile);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
