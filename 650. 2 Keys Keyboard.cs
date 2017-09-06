//Initially on a notepad only one character 'A' is present. You can perform two operations on this notepad for each step:
//1.Copy All: You can copy all the characters present on the notepad (partial copy is not allowed).
//2.Paste: You can paste the characters which are copied last time.
//Given a number n. You have to get exactly n 'A' on the notepad by performing the minimum number of steps permitted. 
//Output the minimum number of steps to get n 'A'.
//The n will be in the range [1, 1000].

public class Solution {
    public int MinSteps(int n) {
        int[,] dp = new int[1, n + 1];
        dp[0, 0] = 0;
        dp[0, 1] = 0;
        if (n >= 2) {
            dp[0, 2] = 2; 
        }
        for (int i = 3; i < n + 1; i++) {
            for (int j = 2; j < i; j++) {
                if (i % j == 0) {
                    dp[0 , i] = dp[0, j] + dp[0, i / j];
                    j = i;
                }
                else {
                    dp[0, i] = i;
                }
            }
        }
        return dp[0, n];
    }
}
