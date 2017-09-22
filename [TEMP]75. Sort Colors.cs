//Problem description: https://leetcode.com/problems/sort-colors/description/
//This is another counting sort example

public class Solution {
    public void SortColors(int[] nums) {
        List<int> list = new List<int>();
        List<int> l = new List<int>();
        for (int k = 0; k < 3; k++) {
            list.Add(0);
        }
        for (int i = 0; i < nums.Length; i++) {
            list[nums[i]] += 1;
        }
        for (int j = 0; j < list.Count; j++) {
            if (list[j] != 0) {
                l.Add(j);
                list[j] -= 1;
                j -= 1;
            }
        }
        for (int k = 0; k < nums.Length; k++) {
            nums[k] = l[k];
        }
    }
}
