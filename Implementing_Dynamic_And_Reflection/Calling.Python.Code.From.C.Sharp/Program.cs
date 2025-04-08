using Calling.Python.Code.From.C.Sharp;
using IronPython.Hosting;

internal class Program
{
    static void Main(string[] args)
    {
        List<object> tweets = GetTweets();

        string report = new Report().Generate(tweets);

        Console.WriteLine(report);
    }

    private static List<object> GetTweets()
    {
        ScriptRuntime py = Python.CreateRuntime();
        dynamic semantic = py.UseFile("../../../Semantic.py");
        dynamic semanticAnalysis = semantic.SemanticAnalysis();

        DateTime date = DateTime.UtcNow;

        var tweets = new List<object>
            {
                new Tweet
                {
                    ScreenName = "SomePerson",
                    CreatedAt = date.AddMinutes(5),
                    Text = "Comment #1",
                    Semantics = GetSemanticText(semanticAnalysis, "Comment #1")
                },
                new Tweet
                {
                    ScreenName = "SomePerson",
                    CreatedAt = date.AddMinutes(7),
                    Text = "Comment #2",
                    Semantics = GetSemanticText(semanticAnalysis, "Comment #2")
                },
                new Tweet
                {
                    ScreenName = "SomePerson",
                    CreatedAt = date.AddMinutes(12),
                    Text = "Comment #3",
                    Semantics = GetSemanticText(semanticAnalysis, "Comment #3")
                },
            };

        return tweets;
    }

    private static string GetSemanticText(dynamic semantic, string text)
    {
        bool result = semantic.Eval(text);
        return result ? "Positive" : "Negative";
    }
}