namespace ParseCommandLine.Core.States;

internal class UnquotedValue : BaseState
{
    public override IState Process(char ch, Context context)
    {
        context.CurrentIndex++;

        switch (ch)
        {
            case Constants.Space:
                context.AddValue();
                return ParseStates.Start;
            case Constants.Escape:
            case Constants.DoubleQuote:
                return ParseStates.Error;
        }

        if (char.IsWhiteSpace(ch) || char.IsControl(ch)) return ParseStates.Error;
        
        context.AppendValueCharacter(ch);
        return this;
    }
}
