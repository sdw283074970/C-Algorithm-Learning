//Problem description: https://leetcode.com/problems/design-hit-counter/description/
//This version may exceed memory limit. Not fixed yet.

public class HitCounter {
    
        int count;
        int prevtmstp;
        int curtmstp;
        Stack<int> sta = new Stack<int>();
    /** Initialize your data structure here. */
    public HitCounter() {
        count = 0;
        prevtmstp = 0;
        curtmstp = 0;
    }
    
    /** Record a hit.
        @param timestamp - The current timestamp (in seconds granularity). */
    public void Hit(int timestamp) {
        curtmstp = timestamp;
        if (curtmstp != prevtmstp) {
            for (int i = 1; i < curtmstp - prevtmstp; i++) {
                sta.Push(0);
            }
            sta.Push(1);
        }
        else {
            int temp = sta.Pop() + 1;
            sta.Push(temp);
        }
        prevtmstp = curtmstp;
    }
    
    /** Return the number of hits in the past 5 minutes.
        @param timestamp - The current timestamp (in seconds granularity). */
    public int GetHits(int timestamp) {
        int len = 0;
        count = 0;
        int[] countarray = sta.ToArray();
        Array.Reverse(countarray);
        if (timestamp <= 300) {
            if (timestamp >= countarray.Length) {
                len = countarray.Length;
            }
            else {
                len = timestamp;
            }
            for (int c = 0; c < len; c++) {
                count += countarray[c];
            }
            return count;
        }
        else {
            if (timestamp >= countarray.Length) {
                len = countarray.Length;
            }
            else {
                len = timestamp;
            }
            for (int k = timestamp - 300; k < len; k++) {
                count += countarray[k];
            }
            return count;
        }
    }
}

/**
 * Your HitCounter object will be instantiated and called as such:
 * HitCounter obj = new HitCounter();
 * obj.Hit(timestamp);
 * int param_2 = obj.GetHits(timestamp);
 */
