﻿namespace ParseCommandLine.Core.States;

internal class QuotedValue : IState
{
    public IState Process(char ch, Context context)
    {
        context.CurrentIndex++;

        switch (ch)
        {
            case Constants.Escape:
                return ParseStates.PotentialEscape;
            case Constants.DoubleQuote:
                return ParseStates.PotentialEndQuotedValue;
            default:
                context.AppendValueCharacter(ch);
                return this;
        }
    }
}
