namespace ParseCommandLine.Core.States;

internal abstract class BaseState : IState
{
    public abstract IState Process(
        char ch,
        Context context);
}
