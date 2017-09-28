//Problem description: 

public class Solution {
    public IList<string> FindRepeatedDnaSequences(string s) {
        IList<string> list = new List<string>();
        if (s.Length == 10) {
            return list;
        }
        for (int i = 0; i < s.Length - 10; i++) {
            string substring = s.Substring(i, 10);
            int temp = s.IndexOf(substring, i + 1);
            if (temp > 0) {
                if (!list.Contains(substring)) {
                    list.Add(substring);
                }
            }
        }
        return list;
    }
}
