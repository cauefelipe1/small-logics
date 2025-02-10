namespace SmallLogics.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {   
        Console.WriteLine(Test("abcded"));
        Console.WriteLine(Test("abdd"));
        Console.WriteLine(Test("aab"));
        Console.WriteLine(Test("aaaaaabc"));
    }
    
    private static string Test(string input)
    {
        var founds = new List<string>();
        var previousChars = new HashSet<char>();
        
        previousChars.Add(input[0]);
        int lastIdx = 0;

        for (int i = 1; i < input.Length; i++)
        {
            if (!previousChars.Add(input[i]))
            {
                founds.Add(input.Substring(lastIdx, i - lastIdx));
                lastIdx = i;
                previousChars.Clear();
            }
        }
        
        if (previousChars.Count > 0)
            founds.Add(input.Substring(lastIdx, input.Length - lastIdx));
        
        
        return founds.Count > 0 ? founds.First(f => f.Length == founds.Max(f => f.Length)) : input;
    }
}