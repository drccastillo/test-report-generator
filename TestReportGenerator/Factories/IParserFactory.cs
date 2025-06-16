using TestReportGenerator.Parsers;

namespace TestReportGenerator.Factories
{
    public interface IParserFactory
    {
        ITestResultParser GetParser(string path);
    }
}