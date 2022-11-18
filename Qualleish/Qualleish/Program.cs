// See https://aka.ms/new-console-template for more information
using Qualleish;

Dictionary<string, (string, string)> words = Lexer.words;
bool back = false;
Console.WriteLine("Welcome to ETQ (English To Qualleish)");
if (args.Length > 0)
{
    if (args[0] == "back")
    {
        back = true;
    }
}
loop:
Console.WriteLine("To Translate (lowercase):");
string tot = Console.ReadLine() + "";
string output = "";
(string, int) nextword = ("", 0);
string[] tots = tot.Split(' ', '.', ',', '!', '?', '\'');
if (back)
{
    for (int i = 0; i < tots.Length + 1; i++)
    {
        if (tots.Length > i)
        {
            if (i != 0 && nextword.Item2 == i)
            {
                output += nextword.Item1 + " ";
            }
            if (tots[i]  == "con" && i != tots.Length)  // yep, its hardcoded (sorry)
            {
                output += "a";
                string tata = words.FirstOrDefault(x => x.Value == (tots[i + 1], "default")).Key + " ";
                if (tata.StartsWith("a") || tata.StartsWith("i") || tata.StartsWith("e") || tata.StartsWith("o") || tata.StartsWith("u")) output += "n";
                output += " ";
                continue;
            }
            if (words.ContainsValue((tots[i], "afternext")))
            {
                string outputa = output.Substring(0, output.Substring(0, output.LastIndexOf(" ")).LastIndexOf(" ") + 1);
                    output = output.Replace(outputa, outputa + words.FirstOrDefault(x => x.Value == (tots[i], "afternext")).Key + " ");
                    continue;
            }
            if (tots[i].EndsWith("j") && tots[i].Length != 2 && !tots[i].EndsWith("jj") && words.ContainsValue((tots[i].Substring(0, tots[i].Length-1), "default")))  // Multiple
            {
                output += words.FirstOrDefault(x => x.Value == (tots[i].Substring(0, tots[i].Length - 1), "default")).Key + "s" + " ";
                continue;
            }
            if (tots[i].EndsWith("n") && !tots[i].EndsWith("nn") && words.ContainsValue((tots[i].Substring(0, tots[i].Length -1), "default")))  // Multiple
            {
                output += words.FirstOrDefault(x => x.Value == (tots[i].Substring(0, tots[i].Length - 1), "default")).Key + "r" + " ";
                continue;
            }
            if (tots[i].EndsWith("jn") && !tots[i].EndsWith("jnjn") && words.ContainsValue((tots[i].Substring(0, tots[i].Length - 2), "default")))  // Multiple
            {
                output += words.FirstOrDefault(x => x.Value == (tots[i].Substring(0, tots[i].Length - 2), "default")).Key + "rs" + " ";
                continue;
            }
            if (!words.ContainsValue((tots[i], "default")))
            {
                output += tots[i] + " ";
                continue;
            }
            output += words.FirstOrDefault(x => x.Value == (tots[i], "default")).Key + " ";
        }
        else
        {
            if (i != 0 && nextword.Item2 == i)
            {
                output += nextword.Item1 + " ";
            }
        }
    }
}
else
{
    for (int i = 0; i < tots.Length + 1; i++)
    {
        if (tots.Length > i)
        {
            if (i != 0 && nextword.Item2 == i)
            {
                output += nextword.Item1 + " ";
            }
            if (words.ContainsKey(tots[i]))
            {
                if (words[tots[i]].Item2 == "afternext")
                {
                    if (tots.Length > i + 1)
                    {
                        nextword = (words[tots[i]].Item1, i + 2);
                    }
                    else
                    {
                        output += words[tots[i]].Item1 + " ";
                    }
                    continue;
                }
            }
            if (tots[i].EndsWith("s") && tots[i].Length != 2 && !tots[i].EndsWith("ss") && words.ContainsKey(tots[i].Substring(0, tots[i].Length - 1)))  // Multiple
            {
                output += words[tots[i].Substring(0, tots[i].Length - 1)].Item1 + "j" + " ";
                continue;
            }
            if (tots[i].EndsWith("r") && !tots[i].EndsWith("rr") && words.ContainsKey(tots[i].Substring(0, tots[i].Length - 1)))  // Multiple
            {
                output += words[tots[i].Substring(0, tots[i].Length - 1)].Item1 + "n" + " ";
                continue;
            }
            if (tots[i].EndsWith("rs") && !tots[i].EndsWith("rsrs") && words.ContainsKey(tots[i].Substring(0, tots[i].Length - 2)))  // Multiple
            {
                output += words[tots[i].Substring(0, tots[i].Length - 2)].Item1 + "jn" + " ";
                continue;
            }
            if (!words.ContainsKey(tots[i]))
            {
                output += tots[i] + " ";
                continue;
            }
            output += words[tots[i]].Item1 + " ";
        }
        else
        {
            if (i != 0 && nextword.Item2 == i)
            {
                output += nextword.Item1 + " ";
            }
        }
    }
}
Console.WriteLine(output);
goto loop;