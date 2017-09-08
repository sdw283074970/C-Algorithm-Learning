
//This is an application of Kadane's Algorithm
//Say you have an array for which the ith element is the price of a given stock on day i.
//If you were only permitted to complete at most one transaction (ie, buy one and sell one share of the stock), 
//design an algorithm to find the maximum profit.

public class Solution {
    public int MaxProfit(int[] prices) {
        int maxCur = 0, maxSoFar = 0;
        for(int i = 1; i < prices.Length; i++) {
            maxCur = Math.Max(0, maxCur += prices[i] - prices[i-1]);
            maxSoFar = Math.Max(maxCur, maxSoFar);
        }
        return maxSoFar;
    }
}
