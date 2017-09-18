//Problem description: https://leetcode.com/problems/partition-equal-subset-sum/description/
//Normal version

public class Solution {
    public bool CanPartition(int[] nums) {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++) {
            sum += nums[i];
        }
        if (sum % 2 != 0) {
            return false;
        }
        int target = sum / 2;
        int[,] dp = new int[nums.Length, target + 1];
        for (int i = 1; i <= target; i++) {
            if (nums[0] == target) {
                dp[0, i] = 1;
            }
        }
        for (int i = 1; i < nums.Length; i++) {
            dp[i, 0] = 1;
        }
        for (int i = 1; i < nums.Length; i++) {
            for (int j = 1; j <= target; j++) {
                if (j - nums[i] >= 0) {
                    dp[i, j] = dp[i - 1, j] + dp[i - 1, j - nums[i]];
                    if (dp[i, j] >= 1) {
                        dp[i, j] = 1;
                    }
                }
                else {
                    dp[i, j] = dp[i - 1, j];
                }
            }
        }
        for (int i = 0; i < nums.Length; i++) {
            if (dp[i, target] == 1) {
                return true;
            }
        }
        return false;
    }
}

//Improved version

public class Solution {
    public bool CanPartition(int[] nums) {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++) {
            sum += nums[i];
        }
        if (sum % 2 != 0) {
            return false;
        }
        int target = sum / 2;
        bool[,] dp = new bool[nums.Length, target + 1];
        for (int i = 1; i <= target; i++) {
            if (nums[0] == target) {
                dp[0, i] = true;
            }
        }
        for (int i = 1; i < nums.Length; i++) {
            dp[i, 0] = true;
        }
        for (int i = 1; i < nums.Length; i++) {
            for (int j = 1; j <= target; j++) {
                if (j - nums[i] >= 0) {
                    dp[i, j] = dp[i - 1, j] || dp[i - 1, j - nums[i]];
                }
                else {
                    dp[i, j] = dp[i - 1, j];
                }
            }
        }
        return dp[nums.Length - 1, target];
    }
}
