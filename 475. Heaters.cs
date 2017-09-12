//Problem description: https://leetcode.com/problems/heaters/description/

public class Solution {
    public int FindRadius(int[] houses, int[] heaters) {
        Array.Sort(houses);
        Array.Sort(heaters);
        int maxDis = 0;
        int nstHeDis = 0;
        int k = 0;
        for (int i = 0; i < houses.Length; i++) {
            while (k < heaters.Length - 1 && Math.Abs(heaters[k + 1] - houses[i]) <= Math.Abs(heaters[k] - houses[i])) {
                k++;
            }
            nstHeDis = Math.Abs(houses[i] - heaters[k]);
            maxDis = Math.Max(maxDis, nstHeDis);
        }
        return maxDis;
    }
}
