//This is a Google test
//Description at "https://leetcode.com/problems/longest-absolute-file-path/description/"
//Using DP Algorithms
//layer tells the length of deep of content
//numT tells the numbers of "\t" (deep of content)

public class Solution {
    public int LengthLongestPath(string input) {
        input = input.Replace("\n", "*");
        string[] paths = input.Split('*');
        int[] layer = new int[paths.Length + 1];
        int maxLen = 0;
        foreach (string s in paths) {
            int numT = s.LastIndexOf("\t") + 1;
            layer[numT + 1] = layer[numT] + s.Length - numT + 1;
            int curLen = layer[numT + 1];
            if (s.Contains(".")) {    //when touch file, meaning it is time to calculate length
                maxLen = Math.Max(maxLen, curLen - 1);
            }
        }
        return maxLen;
    }
}
