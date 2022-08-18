namespace ParseCommandLine.Core.States;

internal interface IState
{
    IState Process(
        char ch,
        Context context);
}
