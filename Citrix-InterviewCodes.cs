using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Solution
{
    static void Main(string[] args)
    {
        string[] counts =
        {
            "900,google.com",
            "60,mail.yahoo.com",
            "10,mobile.sports.yahoo.com",
            "40,sports.yahoo.com",
            "300,yahoo.com",
            "10,stackoverflow.com",
            "2,en.wikipedia.org",
            "1,es.wikipedia.org",
            "1,mobile.sports"
        };

        var valuePairs = extractInfo(counts);
        var keyList = valuePairs.Keys.ToList();

        HashSet<string> distictV = getDistinct(valuePairs);

        Dictionary<string, int> hits = new Dictionary<string, int>();

        foreach (var val in distictV)
        {
            hits.Add(val, 0);
            foreach (KeyValuePair<string, int> Pair in valuePairs)
            {
                if (Pair.Key.EndsWith(val))
                {
                    hits[val] += Pair.Value;
                }
            }
        }       

        foreach(var hit in hits)
        {
            Console.WriteLine(hit.Value +"      "+ hit.Key);
        }
    }

    static HashSet<string> getDistinct(Dictionary<string, int> valuePairs)
    {
        HashSet<string> distictV = new HashSet<string>();
        foreach (KeyValuePair<string, int> Pair in valuePairs)
        {
            string word = Pair.Key;
            distictV.Add(word);
            while (word.Contains("."))
            {
                var index = word.IndexOf(".");
                word = word.Substring(index + 1);
                if (word != "")
                    distictV.Add(word);
            }
        }
        return distictV;
    }


    static Dictionary<string, int> extractInfo(string[] counts)
    {
        var Pairs = new Dictionary<string, int>();
        for (int i = 0; i < counts.Length; i++)
        {
            var temp = counts[i];
            string[] words = temp.Split(',');
            int val = Int32.Parse(words[0]);
            Pairs.Add(words[1], val);
        }
        return Pairs;
    }
}
