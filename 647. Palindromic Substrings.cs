//Given a string, your task is to count how many palindromic substrings in this string.
//The substrings with different start indexes or end indexes are counted as different substrings even they consist of same characters.

public class Solution {
    public int CountSubstrings(string s) {
        int count = 0;
        for (int i = 0; i < s.Length; i++) {
            bool isP = false;
            count += 1;
            for (int k = 0; k < s.Length - 1 - i; k++) {
                int j = s.Length - 1 - k;
                int m = i;
                while (j > m ){
                    if (s[m] == s[j]) {
                        j -= 1;
                        m += 1;
                    }
                    else {
                        break;
                    }
                }
                if (m == j || m - j == 1) {
                    count += 1;
                }
            }
        }
        return count;
    }
}
