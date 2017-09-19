//Problem description: https://leetcode.com/problems/zigzag-conversion/description/
//New thing: StringBuilder

public class Solution {
    public string Convert(string s, int numRows) {
        Stack<char> sta = new Stack<char>();
        for (int idx = 0;  idx < s.Length; idx++) {
            sta.Push(s[idx]);
        }
        char[] c = sta.ToArray();
        Array.Reverse(c);
        StringBuilder[] sb = new StringBuilder[numRows];
        for (int idx = 0; idx < sb.Length; idx++) {
            sb[idx] = new StringBuilder();
        }
        int i = 0;
        while (i < c.Length) {
            for (int idx = 0; idx < numRows && i < c.Length; idx++) {
                sb[idx].Append(c[i++]);
            }
            for (int idx = numRows - 2; idx >= 1 && i < c.Length; idx--) {
                sb[idx].Append(c[i++]);
            }
        }
        for (int idx = 1; idx < sb.Length; idx++) {
            sb[0].Append(sb[idx]);
        }
        string res;
        res = sb[0].ToString();
        return res;
    }
}
