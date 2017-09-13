//Problem description: https://leetcode.com/problems/strobogrammatic-number/description/

public class Solution {
    
    public bool contains(string str1, string str2) {
        return (str1.IndexOf(str2, StringComparison.Ordinal) >= 0);
    }
    
    public bool IsStrobogrammatic(string num) {
        for (int i = 0, j = num.Length - 1; i <= j; i++, j--) {
            if (!contains("00 11 88 969", String.Concat(Convert.ToString(num[i]), Convert.ToString(num[j])))) {
                return false;
            }
        }
        return true;
    } 
}
