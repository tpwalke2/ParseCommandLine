using System;
using System.Text.Json.Serialization;
using Xunit;

namespace ParseCommandLine.Core.Tests;

public class ParserTests
{
    [Fact]
    public void ParseOneArgument_BooleanFlag()
    {
        var result = Parser.Parse("-arg1");

        Assert.Equal(1, result.Count);
        Assert.True(result.Arg<bool>("arg1"));
    }
    
    [Fact]
    public void ParseOneArgument_Int()
    {
        var result = Parser.Parse("-arg1=42");

        Assert.Equal(1, result.Count);
        Assert.Equal(42, result.Arg<int>("arg1"));
    }
    
    [Fact]
    public void ParseOneArgument_String()
    {
        var result = Parser.Parse("-arg1=\"Hello World!\"");

        Assert.Equal(1, result.Count);
        Assert.Equal("Hello World!", result.Arg<string>("arg1"));
    }
    
    [Fact]
    public void ParseOneArgument_StringWithEscapedEscape()
    {
        var result = Parser.Parse("-arg1=\"2 \\\\ 1 = 1\"");

        Assert.Equal(1, result.Count);
        Assert.Equal(@"2 \ 1 = 1", result.Arg<string>("arg1"));
    }
    
    [Fact]
    public void ParseOneArgument_StringWithEscapedDoubleQuote()
    {
        var result = Parser.Parse("-arg1=\"Hello \\\"World\\\"!\"");

        Assert.Equal(1, result.Count);
        Assert.Equal("""Hello "World"!""", result.Arg<string>("arg1"));
    }
    
    [Fact]
    public void ParseTwoArguments()
    {
        var result = Parser.Parse("-arg1 -arg2=42");

        Assert.Equal(2, result.Count);
        Assert.True(result.Arg<bool>("arg1"));
        Assert.Equal(42, result.Arg<int>("arg2"));
    }

    [Fact]
    public void ParseJson()
    {
        var parsed = Parser.Parse("-arg1=\"{\\\"flag\\\": true,\\\"body\\\":\\\"This is the body\\\"}\"");

        var result = parsed.Arg<TestClass>("arg1")!;
        Assert.True(result.Flag);
        Assert.Equal("This is the body", result.Body);
    }

    private class TestClass
    {
        [JsonPropertyName("flag")]
        public bool Flag { get; set; }
        [JsonPropertyName("body")]
        public string Body { get; set; }
    }

    [Theory]
    [InlineData("hi")]
    [InlineData("- -arg1")]
    [InlineData("-1arg")]
    [InlineData("-arg1=")]
    [InlineData("-arg1= -arg2")]
    [InlineData(@"-arg1=""Hi -arg2")]
    [InlineData(@"-arg1=42"" -arg2")]
    [InlineData("""
                -arg1="Hi \ hi"
                """)]
    public void ParseErrors(string commandLine)
    {
        Assert.Throws<FormatException>(() => Parser.Parse(commandLine));
    }
    
    [Fact]
    public void ParseArrayTwoArguments()
    {
        var result = Parser.Parse(["-arg1", "-arg2=42"]);

        Assert.Equal(2, result.Count);
        Assert.True(result.Arg<bool>("arg1"));
        Assert.Equal(42, result.Arg<int>("arg2"));
    }
}
