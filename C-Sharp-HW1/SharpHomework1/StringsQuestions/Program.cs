// See https://aka.ms/new-console-template for more information
using System.Text;

static string reverseStr(string str) {
    StringBuilder b = new StringBuilder();
    foreach (char c in str) {
        b.Insert(0, c);
    }
    return b.ToString();
}

static string reverseII(string str) {
    int n = str.Length;
    List<string> words = new List<string>();
    List<int> puncPos = new List<int>();
    string pun = ",:;=()&[]\"'\\/!? ";
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < n; i++) {
        if (pun.Contains(str[i]))
        {
            if(sb.Length >0) words.Add(sb.ToString());
            words.Add(str.Substring(i, 1));
            puncPos.Add(words.Count-1);
            sb.Clear();
        }
        else {
            sb.Append(str[i]);

        }
    }
    if (sb.Length != 0) words.Append(sb.ToString());

    int left = 0, right = words.Count-1;
    while (left <= right) {
        if (puncPos.Contains(left))
        {
            left++;
            continue;
        }
        if (puncPos.Contains(right)) {
            right--;
            continue;
        }
        string temp = words[right];
        words[right] = words[left];
        words[left] = temp;
        left++;
        right--;

    }
    StringBuilder res = new StringBuilder();
    foreach (String s in words) res.Append(s);
    return res.ToString();


}

static void FindPalindromes(string s)
{
    List<string> results = new List<string>();
    int n = s.Length;
    for (int i = 0; i < n; i++)
    {
        for (int j = i; j < n; j++)
        {
            string subStr = s.Substring(i, j - i + 1);
            if (checkPalindrome(subStr) && !results.Contains(subStr)) results.Add(subStr);

        }
    }
    results.Sort();
    for (int i = 0; i < results.Count; i++)
    {
        Console.Write(results[i]);
        if (i < results.Count - 1) Console.Write(", ");
    }
    Console.Write('\n');

}
static bool checkPalindrome(string s) {
    int n = s.Length;
    if (n == 1) return false;
    int left = 0, right = n - 1;
    while (left <= right) {
        if (s[left] != s[right]) return false;
        left++;
        right--;
    }
    return true;
}

static void ParseURL(string url)
{
    url = url + "/";
    string protocol = string.Empty, server = string.Empty, resource = string.Empty;
    int start = 0;
    int n = url.Length;
    for (int i = 0; i < n; i++)
    {
        if (i < start) continue;
        if (url[i] == ':')
        {
            protocol = url.Substring(0, i);
            start = i + 3;
            continue;
        }
        else if (url[i] == '/' && url[i - 1] != '/')
        {
            if (server.Equals(String.Empty)) server = url.Substring(start, i - start);
            else resource = url.Substring(start, i - start);
            start = i + 1;
        }
    }

    Console.WriteLine($"[protocol] = \"{protocol}\"");
    Console.WriteLine($"[server] = \"{server}\"");
    Console.WriteLine($"[resource] = \"{resource}\"");
}

int[] a = new int[] { 23, 12, 44, 2, 5 };
int[] b = (int[])a.Clone();
int[] c = new int[5];
Console.WriteLine(String.Join(',', a));
a.CopyTo(c, 0);
a[0] = 10;
Console.WriteLine(String.Join(',', a));
Console.WriteLine(String.Join(',', b));
Console.WriteLine(String.Join(',', c));



Console.WriteLine(reverseStr("Hello"));
Console.WriteLine(reverseII("The quick brown fox jumps over the lazy dog /Yes! Really!!!/."));
FindPalindromes("Hi,exe? ABBA! Hog fully a string: ExE. Bob");
ParseURL("Http://www.apple.com");