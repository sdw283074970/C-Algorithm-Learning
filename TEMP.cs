

public class HitCounter {
    

    /** Initialize your data structure here. */
    public HitCounter() {
        int count = 0;
        int prevtmstp = 0;
        int curtmstp = 0;
        Stack<int> sta = new Stack<int>();
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
        if (sta.Count <= 300) {
            int[] countarray = sta.ToArray();
            foreach (int c in countarray) {
                count += c;
            }
            return count;
        }
        else {
            int[] countarray = sta.ToArray();
            Array.Reverse(countarray);
            for (int k = timestamp - 300; k < timestamp; k++) {
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
