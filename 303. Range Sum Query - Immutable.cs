//Given an integer array nums, find the sum of the elements between indices i and j (i ≤ j), inclusive.
//Hint: Given an array {a0, a1, a2, ... , an}; ai + aj = Sj -S(i - 1).

public class NumArray {
    
    public int[] nums;

    public NumArray(int[] nums) {
        for (int i = 1; i < nums.Length; i++) {
            nums[i] += nums[i -1];
        }
        this.nums = nums;
    }
    
    public int SumRange(int i, int j) {
        if (i == 0) {
            return nums[j];
        }
        return nums[j] - nums[i - 1];
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(i,j);
 */
