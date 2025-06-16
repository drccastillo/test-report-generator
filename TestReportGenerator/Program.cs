using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestReportGenerator;
using TestReportGenerator.Services;
using TestReportGenerator.Factories;
using TestReportGenerator.Parsers;
using TestReportGenerator.Analysis;
using TestReportGenerator.Reports;
using TestReportGenerator.Reports.Builders;
using TestReportGenerator.Facades;

var builder = Host.CreateApplicationBuilder(args);
var services = builder.Services;

// Register services with dependency injection
services.AddSingleton<IFileReader, FileReader>();
services.AddSingleton<IParserFactory, ParserFactory>();
services.AddSingleton<CsvParser>();
services.AddSingleton<JsonParser>();
services.AddSingleton<XmlParser>();
services.AddSingleton<ITestAnalyzer, TestAnalyzer>();
services.AddSingleton<ReportBuilder>();
services.AddSingleton<IReportGenerator, ConsoleReportGenerator>();
services.AddSingleton<ITestReportFacade, TestReportFacade>();
services.AddSingleton<ReportGeneratorCli>();

using var host = builder.Build();

host.Services.GetRequiredService<ReportGeneratorCli>().Run(args);