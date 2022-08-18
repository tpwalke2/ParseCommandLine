namespace ParseCommandLine.Core.States;

internal class Error : BaseState
{
    public override IState Process(char ch, Context context)
    {
        throw new FormatException($"Error parsing command line at position {context.CurrentIndex}");
    }
}
