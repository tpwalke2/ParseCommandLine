namespace ParseCommandLine.Core.States;

internal class Key : IState
{
    public IState Process(char ch, Context context)
    {
        context.CurrentIndex++;

        if (char.IsLetterOrDigit(ch) || ch == Constants.Underscore)
        {
            context.AppendNameCharacter(ch);
            return this;
        }

        switch (ch)
        {
            case Constants.ArgumentValueSeparator:
                return ParseStates.StartValue;
            case Constants.Space:
                context.AddValue("true");
                return ParseStates.Start;
            default:
                return ParseStates.Error;
        }
    }
}
