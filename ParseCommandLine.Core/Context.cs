using System.Text;

namespace ParseCommandLine.Core;

internal sealed class Context
{
    private readonly StringBuilder _nameBuffer = new();
    private readonly StringBuilder _valueBuffer = new();
    public IList<KeyValuePair<string, string>> ArgumentValues { get; } = new List<KeyValuePair<string, string>>();
    public int CurrentIndex { get; set; }
    
    public void AppendNameCharacter(char ch)
    {
        _nameBuffer.Append(ch);
    }
    
    public void AppendValueCharacter(char ch)
    {
        _valueBuffer.Append(ch);
    }

    public void AddValue(string defaultValue = "")
    {
        ArgumentValues.Add(new KeyValuePair<string, string>(
                               _nameBuffer.ToString(),
                               _valueBuffer.Length <= 0
                                   ? defaultValue
                                   : _valueBuffer.ToString()));
        _nameBuffer.Clear();
        _valueBuffer.Clear();
    }
}