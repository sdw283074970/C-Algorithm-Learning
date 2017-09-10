//This is a Google test
//Description: https://leetcode.com/problems/license-key-formatting/description/

public class Solution {
    public string LicenseKeyFormatting(string S, int K) {
        S = S.Replace("-", "");
        S = S.ToUpper();
        if (S.Length <= K) {
            return S;
        }
        if (S.Length % K == 0) {
            for (int i = K; i < S.Length; i += K + 1) {
                S = S.Insert(i, "-");
            }
        }
        else {
            string head = S.Substring(0, S.Length % K);
            string end = S.Substring(S.Length % K);
            for (int j = K; j < end.Length; j += K + 1) {
                end = end.Insert(j, "-");
            }
            S = string.Concat(head, "-", end);
        }
        return S;
    }
}
