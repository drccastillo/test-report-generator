using System;
using TestReportGenerator.Parsers;
using TestReportGenerator.Services;

namespace TestReportGenerator.Factories
{
    public class ParserFactory : IParserFactory
    {
        private readonly IFileReader _fileReader;
        private readonly IServiceProvider _serviceProvider;

        public ParserFactory(IFileReader fileReader, IServiceProvider serviceProvider)
        {
            _fileReader = fileReader;
            _serviceProvider = serviceProvider;
        }

        public ITestResultParser GetParser(string path)
        {
            var extension = System.IO.Path.GetExtension(path)?.ToLowerInvariant();
            return extension switch
            {
                ".csv" => (ITestResultParser)_serviceProvider.GetService(typeof(CsvParser))!,
                ".json" => (ITestResultParser)_serviceProvider.GetService(typeof(JsonParser))!,
                ".xml" => (ITestResultParser)_serviceProvider.GetService(typeof(XmlParser))!,
                _ => throw new NotSupportedException($"Unsupported file extension: {extension}")
            };
        }
    }
}