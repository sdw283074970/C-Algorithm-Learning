//This is Kadane's Algorithm
//Find the contiguous subarray within an array (containing at least one number) which has the largest sum.
//For example, given the array [-2,1,-3,4,-1,2,1,-5,4],
//the contiguous subarray [4,-1,2,1] has the largest sum = 6.

public class Solution {
    public int MaxSubArray(int[] nums) {
        int maxcurrent = 0;
        int maxsofar = nums[0];
        for (int i = 0; i < nums.Length; i++) {
            maxcurrent = Math.Max(nums[i], maxcurrent + nums[i]);
            maxsofar = Math.Max(maxcurrent, maxsofar);
        }
        return maxsofar;
    }
}
