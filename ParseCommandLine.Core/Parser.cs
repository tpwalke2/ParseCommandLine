using ParseCommandLine.Core.States;

namespace ParseCommandLine.Core;

public class Parser : IParser
{
    public ParseResult Parse(string arguments)
    {
        return new ParseResult(
            DoParse(
                arguments,
                new Context()));
    }

    private static IEnumerable<KeyValuePair<string, string>> DoParse(
        string input,
        Context context)
    {
        var finalState = input.Aggregate(
            ParseStates.Start,
            (current, ch) => current.Process(ch, context));

        if (finalState == ParseStates.Key)
        {
            context.AddValue("true");
            return context.ArgumentValues;
        }

        if (finalState != ParseStates.PotentialEndQuotedValue && finalState != ParseStates.UnquotedValue)
        {
            ParseStates.Error.Process(default, context);
        }

        context.AddValue();
        return context.ArgumentValues;
    }
}
