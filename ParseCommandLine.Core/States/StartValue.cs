namespace ParseCommandLine.Core.States;

internal class StartValue : BaseState
{
    public override IState Process(char ch, Context context)
    {
        context.CurrentIndex++;

        if (char.IsWhiteSpace(ch) || char.IsControl(ch)) return ParseStates.Error;
        
        switch (ch)
        {
            case Constants.DoubleQuote:
                return ParseStates.QuotedValue;
            case Constants.Escape:
                return ParseStates.Error;
            default:
                context.AppendValueCharacter(ch);
                return ParseStates.UnquotedValue;
        }
    }
}
