namespace ParseCommandLine.Core.States;

internal class StartKey : BaseState
{
    public override IState Process(char ch, Context context)
    {
        context.CurrentIndex++;

        if (!char.IsLetter(ch)) return ParseStates.Error;
        
        context.AppendNameCharacter(ch);
        return ParseStates.Key;
    }
}
