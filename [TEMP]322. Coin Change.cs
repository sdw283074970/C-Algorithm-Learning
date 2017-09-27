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
        return dp[coins.Length - 1, amount] > 0 ? dp[coins.Length - 1, amount] : -1;
    }
}

//An improved version

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
                int k = 1;
                if (j % coins[i] == 0) {
                    if (dp[i - 1, j] != 0) {
                        dp[i, j] = Math.Min(dp[i - 1, j], j / coins[i]);
                    }
                    else if (dp[i - 1, j] == 0) {
                        dp[i, j] = j / coins[i];
                    }
                }
                else if (j > coins[i]) {
                    dp[i, j] = dp[i - 1, j];
                    while (k <= j / coins[i]) {
                        if (dp[i - 1, j - k * coins[i]] != 0) {
                            if (dp[i, j] == 0) {
                                dp[i, j] = dp[i - 1, j - k * coins[i]] + k;
                            }
                            else if (dp[i, j] > 0) {
                                dp[i ,j] = Math.Min(dp[i, j], dp[i - 1, j - k * coins[i]] + k);
                                k++;
                            }
                        }
                        else if (dp[i - 1, j - k * coins[i]] == 0) {
                            k++;
                        }
                    }
                    if (dp[i - 1, j] != 0) {
                        dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j]);
                    }
                }
                else if (j < coins[i]) {
                    dp[i, j] = dp[i - 1, j];
                }
            }
        }
        return dp[coins.Length - 1, amount] > 0 ? dp[coins.Length - 1, amount] : -1;
    }
}

//Version 3: time exceeded

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
                int k = 1, m = 1;
                if (j % coins[i] == 0) {
                    if (dp[i - 1, j] != 0) {
                        dp[i, j] = Math.Min(dp[i - 1, j], j / coins[i]);
                    }
                    else if (dp[i - 1, j] == 0) {
                        dp[i, j] = j / coins[i];
                    }
                }
                else if (j > coins[i]) {
                    bool isExist = false;
                    while (k <= j / coins[i]) {
                        if (dp[i - 1, j - k * coins[i]] != 0) {
                            isExist = true;
                            dp[i, j] = dp[i - 1, j - k * coins[i]] + k;
                            k = j / coins[i] + 1;
                        }
                        k += 1;
                    }
                    if (isExist == false) {
                        dp[i, j] = dp[i - 1, j];
                    }
                    else if (isExist == true) {
                        while (m <= j / coins[i]) {
                            if (dp[i - 1, j - m * coins[i]] != 0) {
                                dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j - m * coins[i]] + m);
                            }
                        }
                        if (dp[i - 1, j] != 0) {
                            dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j]);
                        }
                    }
                }
                else if (j < coins[i]) {
                    dp[i, j] = dp[i - 1, j];
                }
            }
        }
        return dp[coins.Length - 1, amount] > 0 ? dp[coins.Length - 1, amount] : -1;
    }
}

//Worked version

public class Solution {
    public int CoinChange(int[] coins, int amount) {
        int[] dp = new int[amount + 1];
        for (int i = 0; i <= amount; i++) {
            if (i % coins[0] == 0) {
                dp[i] = i / coins[0];
            }
            else {
                dp[i] = amount + 1;
            }
            for (int j = 0; j < coins.Length; j++) {
                if (coins[j] <= i) {
                    dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                }
            }
        }
        if (dp[amount] > amount) {
            return -1;
        }
        else {
            return dp[amount];
        }
    }
}
