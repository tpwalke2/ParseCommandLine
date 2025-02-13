using ParseCommandLine.Core.States;

namespace ParseCommandLine.Core;

public static class Parser
{
    public static ParseResult Parse(string arguments) => new(
            DoParse(
                arguments,
                new Context()));

    public static ParseResult Parse(string[] arguments) => Parse(string.Join(' ', arguments));

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
            ParseStates.Error.Process('\0', context);
        }

        context.AddValue();
        return context.ArgumentValues;
    }
}
