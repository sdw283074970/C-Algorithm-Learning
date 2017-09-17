//Problem discription: https://leetcode.com/problems/target-sum/description/
//Could be simplifed, not fixed yet

public class Solution {
    public int FindTargetSumWays(int[] nums, int S) {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++) {
            sum += nums[i];
        }
        if (S > sum || (S + sum) % 2 > 0) {
            return 0;
        }
        int target = (S + sum) / 2;
        int[,] dp = new int[nums.Length, target + 1];
        if (sum == 0 && target == 0) {
            dp[0, 0] = 1;
            for (int i = 1; i < nums.Length; i++) {
                dp[i, 0] = dp[i - 1, 0] + dp[i - 1, 0] + 1; 
            }
            return dp[nums.Length - 1, 0] + 1;
        }
        if (target == 0 && nums.Length != 1) {
            dp[0, 0] = 1;
            for (int i = 1 ; i < nums.Length; i++) {
                if (nums[i] == 0) {
                    dp[i, 0] = dp[i - 1, 0] + dp[i - 1, 0] + 1;
                }
                else {
                    dp[i, 0] = dp[i - 1, 0];
                }
            }
            return dp[nums.Length - 1, 0] + 1;
        }
        Array.Sort(nums);
        Array.Reverse(nums);
        for (int i = 0; i < nums.Length; i++) {
            dp[i, 0] = 1;
        }
        for (int i = 1; i < target + 1; i++) {
            if (i == nums[0]) {
                dp[0, i] = 1;
                
            }
        }
        for (int i = 1; i < nums.Length; i++) {
            for (int j = 1; j <= target; j++) {
                if (j - nums[i] >= 0) {
                    dp[i, j] = dp[i - 1, j] + dp[i -1, j -nums[i]];
                }
                else if (nums[i] == 0) {
                    dp[i, j] = dp[i - 1, j] * 3;
                }
                else {
                    dp[i ,j] = dp[i -1, j];
                }
            }
        }
        return dp[nums.Length - 1, target];
    }
}
