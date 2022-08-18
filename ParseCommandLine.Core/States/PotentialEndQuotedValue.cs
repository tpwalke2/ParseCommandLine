namespace ParseCommandLine.Core.States;

internal class PotentialEndQuotedValue : BaseState
{
    public override IState Process(char ch, Context context)
    {
        context.CurrentIndex++;

        switch (ch)
        {
            case Constants.Space:
                context.AddValue();
                return ParseStates.Start;
            default:
                return ParseStates.Error;
        }
    }
}
