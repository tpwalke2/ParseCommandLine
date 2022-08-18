namespace ParseCommandLine.Core.States;

internal class PotentialEscape : BaseState
{
    public override IState Process(char ch, Context context)
    {
        context.CurrentIndex++;

        switch (ch)
        {
            case Constants.Escape:
            case Constants.DoubleQuote:
                context.AppendValueCharacter(ch);
                return ParseStates.QuotedValue;
            default:
                return ParseStates.Error;
        }
    }
}
