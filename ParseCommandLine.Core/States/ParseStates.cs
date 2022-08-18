namespace ParseCommandLine.Core.States;

internal static class ParseStates
{
    public static readonly IState Start = new Start();
    public static readonly IState Error = new Error();
    public static readonly IState StartKey = new StartKey();
    public static readonly IState Key = new Key();
    public static readonly IState StartValue = new StartValue();
    public static readonly IState QuotedValue = new QuotedValue();
    public static readonly IState UnquotedValue = new UnquotedValue();
    public static readonly IState PotentialEscape = new PotentialEscape();
    public static readonly IState PotentialEndQuotedValue = new PotentialEndQuotedValue();
}
