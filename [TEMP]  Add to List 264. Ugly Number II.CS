//Problem description: https://leetcode.com/problems/ugly-number-ii/description/

public class Solution {
    public int NthUglyNumber(int n) {
		if (n <= 0) {
           return 0; 
        }
		int a = 0, b = 0, c = 0;
		ArrayList table = new ArrayList();
		table.Add(1);
		while(table.Count < n) {
			int next_val = Math.Min(Convert.ToInt32(table[a]) * 2, Math.Min(Convert.ToInt32(table[b]) * 3, Convert.ToInt32(table[c]) * 5));
			table.Add(next_val);
			if (Convert.ToInt32(table[a]) * 2 == next_val) a++;
			if (Convert.ToInt32(table[b]) * 3 == next_val) b++;
			if (Convert.ToInt32(table[c]) * 5 == next_val) c++;
		}
		return Convert.ToInt32(table[table.Count - 1]);
    }
}

//Another version

public class Solution {
    public int NthUglyNumber(int n) {
        int[] ugly = new int[n];
        ugly[0] = 1;
        int index = 2;
        for (int i = 1; i < n; i++) {
            bool isContinue = true;
            while (isContinue) {
                if (ShortDivide(index) == 1 || ShortDivide(index) == 2 || ShortDivide(index) == 3 || ShortDivide(index) == 5) {
                    ugly[i] = index;
                    index++;
                    isContinue = false;
                }
                else {
                    index++;
                }
            }
        }
        return ugly[n - 1];
    }
    public int ShortDivide(int n) {
        if (n % 5 != 0 && n % 3 != 0 && n % 2 != 0) {
            return n;
        }
        while (n % 5 == 0 || n % 3 == 0 || n % 2 == 0) {
            if (n % 5 == 0) {
                n = n / 5;
            }
            else if (n % 3 == 0) {
                n = n / 3;
            }
            else if (n % 2 == 0){
                n = n / 2;
            }
        }
        return n;
    }
}
