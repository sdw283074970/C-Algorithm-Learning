//Given a sorted array consisting of only integers where every element appears twice except for one element which appears once. 
//Find this single element that appears only once.

//Normal Version:

public class Solution {
    public int SingleNonDuplicate(int[] nums) {
        for (int i = 1; i < nums.Length - 2; i++) {
            if (nums[i] != nums[i - 1] && nums[i] != nums[i + 1]) {
                return nums[i];
            }
        }
        if (nums[0] == nums[1]) {
            return nums[nums.Length - 1];
        }
        else {
            return nums[0];
        }
    }
}

//Binary Tree Version:

public class Solution {
    public int SingleNonDuplicate(int[] nums) {
        int n=nums.Length, lo=0, hi=n/2;
            while (lo < hi) {
                int m = (lo + hi) / 2;
                if (nums[2*m]!=nums[2*m+1]) hi = m;
                else lo = m+1;
            }
            return nums[2*lo];
        
    }
}
