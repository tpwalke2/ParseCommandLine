namespace ParseCommandLine.Core.States;

internal class Start : BaseState
{
    public override IState Process(char ch, Context context)
    {
        context.CurrentIndex++;
        
        return ch switch
        {
            Constants.ArgumentPrefix => ParseStates.StartKey,
            _ => ParseStates.Error
        };
    }
}
