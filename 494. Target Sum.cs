//Problem discription: https://leetcode.com/problems/target-sum/description/

public class Solution {
    public int FindTargetSumWays(int[] nums, int S) {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++) {
            sum += nums[i];
        }
        if (S > sum || (S + sum) % 2 > 0) {
            return 0;
        }
        if (S == 0) {
            return 1;
        }
        int target = (S + sum) / 2;
        int[,] dp = new int[nums.Length, target + 1];
        for (int i = 0; i < nums.Length; i++) {
            dp[i, 0] = 1;
        }
        for (int i = 1; i < target + 1; i++) {
            if (i == nums[0]) {
                dp[0, i] = 1;
            }
        }
        for (int i = 1; i < nums.Length; i++) {
            for (int j = 1; j < target + 1; j++) {
                if (i - nums[i] >= 0) {
                    dp[i, j] = dp[i - 1, j] + dp[i -1, j -nums[i]];
                }
                else {
                    dp[i ,j] = dp[i -1, j];
                }
            }
        }
        return dp[nums.Length - 1, target];
    }
}
