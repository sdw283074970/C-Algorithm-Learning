//Problem description: https://leetcode.com/problems/coin-change/description/

//My own version, need to be fixed

public class Solution {
    public int CoinChange(int[] coins, int amount) {
        if (amount == 0) {
            return 0;
        }
        int[,] dp = new int[coins.Length, amount + 1];
        for (int i = 0; i < coins.Length; i++) {
            dp[i, 0] = 1;
        }
        for (int i = 1; i <= amount; i++) {
            if (i % coins[0] == 0) {
                dp[0, i] = i / coins[0];
            }
        }
        for (int i = 1; i < coins.Length; i++) {
            for (int j = 1; j <= amount; j++) {
                if (j % coins[i] == 0) {
                    if (dp[i - 1, j] != 0) {
                        dp[i, j] = Math.Min(dp[i - 1, j], j / coins[i]);
                    }
                    else {
                        dp[i, j] = j / coins[i];
                    }
                }
                else if (j > coins[i]) {
                    if (dp[i - 1, j % coins[i]] == 0) {
                        dp[i, j] = dp[i - 1, j];
                    }
                    else if (dp[i - 1, j % coins[i]] != 0) {
                        dp[i, j] = dp[i - 1, j % coins[i]] + j / coins[i];
                    }
                }
                else if (j < coins[i]){
                    dp[i, j] = dp[i - 1, j];
                }
            }
        }
        if (dp[coins.Length - 1, amount] != 0) {
            return dp[coins.Length - 1, amount];
        }
        else {
            return -1;
        }
    }
}
