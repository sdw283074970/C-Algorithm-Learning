//Problem description: https://leetcode.com/problems/perfect-squares/description/

public class Solution {
    public int NumSquares(int n) {
        Stack<int> sta = new Stack<int>();
        for (int i = 1; i <= 100; i++) {
            sta.Push(i * i);
        }
        int[] nums = sta.ToArray();
        Array.Reverse(nums);
        int[, ] dp = new int[nums.Length, n + 1];
        for (int c = 1; c <= n; c++) {
            dp[0, c] = c;
        }
        for (int r = 0; r < nums.Length; r++) {
            dp[r, 1] = 1;
        }
        for (int j = 1; j < nums.Length; j++) {
            for (int k = 2; k <= n; k++) {
                if (k % nums[j] == 0) {
                    dp[j, k] = k / nums[j];
                }
                else if (k > nums[j]) {
                    dp[j, k] = Math.Min(dp[j - 1, k], dp[j, k - nums[j]] + 1);
                }
                else if (k < nums[j]) {
                    dp[j, k] = dp[j - 1, k];
                }
                if (n < nums[j]) {
                    return dp[j - 1, n];
                }
            }
        }
        return dp[nums.Length - 1, n];
    }
}
