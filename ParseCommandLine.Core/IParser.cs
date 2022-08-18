namespace ParseCommandLine.Core;

public interface IParser
{
    ParseResult Parse(string arguments);
}
