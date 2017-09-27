//Problem description: https://leetcode.com/problems/coin-change-2/description/

public class Solution {
    public int Change(int amount, int[] coins) {
        if (coins.Length < 1 && amount == 0) {
            return 1;
        }
        else if (coins.Length < 1) {
            return 0;
        }
        int[,] dp = new int[coins.Length, amount + 1];
        for (int i = 0; i < coins.Length; i++) {
            dp[i, 0] = 1;
        }
        for (int i = 1; i <= amount; i++) {
            if (i % coins[0] == 0) {
                dp[0, i] = 1;
            }
        }
        for (int i = 1; i < coins.Length; i++) {
            for (int j = 1; j <= amount; j++) {
                if (j >= coins[i]) {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - coins[i]];
                }
                else {
                    dp[i, j] = dp[i - 1, j];
                }
            }
        }
        return dp[coins.Length - 1, amount];
    }
}
