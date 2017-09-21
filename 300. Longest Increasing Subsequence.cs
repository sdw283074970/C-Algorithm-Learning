//Problem descriptiong: https://leetcode.com/problems/longest-increasing-subsequence/description/
//This is a hard one

public class Solution {
    public int LengthOfLIS(int[] nums) {
        if (nums.Length == 0) {
            return 0;
        }
        Stack<int> sta = new Stack<int>();
        int maxLength = 1;
        for (int i = 0; i < nums.Length - 1; i++) {
            sta.Clear();
            sta.Push(nums[i]);
            int valid = nums[i];
            for (int j = i; j < nums.Length - 1; j++) {
                if (nums[j] > valid && nums[j] < nums[j + 1] && nums[j] < sta.Peek()) {
                    sta.Pop();
                    sta.Push(nums[j]);
                    valid = nums[j];
                }
                else if (nums[j] > valid && nums[j] < nums[j + 1]) {
                    sta.Push(nums[j]);
                    valid = nums[j];
                }
                else if (nums[j] > sta.Peek()) {
                    sta.Push(nums[j]);
                }
                if (j == nums.Length - 2 && nums[j] > sta.Peek()) {
                    sta.Push(nums[j]);
                }
                if (j == nums.Length - 2 && nums[nums.Length - 1] > sta.Peek()) {
                    sta.Push(nums[nums.Length - 1]);
                }
                maxLength = Math.Max(maxLength, sta.Count());
            }
        }
        return maxLength;
    }
}
