namespace ParseCommandLine.Core.States;

internal class Start : IState
{
    public IState Process(char ch, Context context)
    {
        context.CurrentIndex++;
        
        return ch switch
        {
            Constants.ArgumentPrefix => ParseStates.StartKey,
            _ => ParseStates.Error
        };
    }
}
