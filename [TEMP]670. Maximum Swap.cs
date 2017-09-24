//Problem description: https://leetcode.com/problems/maximum-swap/description/

public class Solution {
    public int MaximumSwap(int num) {
        string nums = Convert.ToString(num);
        int maxN = num;
        string tempS = nums;
        for (int i = 0; i < nums.Length - 1; i++) {
            for (int j = i + 1; j < nums.Length; j++) {
                tempS = NumSwap(nums, i, j);
                maxN = Math.Max(maxN, Convert.ToInt32(tempS));
            }
        }
        return maxN;
    }
    
    public string NumSwap(string nums, int i, int j) {
        string tempI = Convert.ToString(nums[i]);
        string tempJ = Convert.ToString(nums[j]);
        nums = nums.Remove(j, 1);
        nums = nums.Remove(i, 1);
        nums = nums.Insert(i, tempJ);
        nums = nums.Insert(j, tempI);
        return nums;
    }
}
