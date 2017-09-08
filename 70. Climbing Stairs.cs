//You are climbing a stair case. It takes n steps to reach to the top.
//Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

//My solution
//There is a bug says function zh attemped to divid zero. Not fixed yet.

public class MySolution {
    public int jc(int c) {
        int jc1 = 1;
        for (int i = 1; i <= c; i++) {
            jc1 *= i;
        }
        return jc1;
    }
    
    public int zh(int m, int n) {
        return jc(n) / jc(m) / jc(n - m);
    } 
    
    public int ClimbStairs(int n) {
        int res = 0;
        int[, ] dp = new int[n / 2 + 1, n + 1];
        for (int k = 0; k < n + 1; k++) {
            dp[0, k] = 1;
        }
        if (n == 2) {
            dp[1, 2] = 1;
        }
        for (int i = 1; i < n / 2 + 1; i++) {
            for (int j = 3; j < n + 1; j++) {
                if (j % 2 != 0) {
                    dp[i, j] = zh(i, j -i);
                }
                else {
                    dp[i, j] = 1;
                }
            }
        }
        for (int m = 0; m < n / 2 + 1; m++) {
            res += dp[m, n];
        }
        return res;
    }
}

//Master's solution
//Variable 'a' tells you the number of ways to reach the current step, and 'b' tells you the number of ways to reach the next step.

public class DaLaoDeSolution {
    public int ClimbStairs(int n) {
    int a = 1, b = 1;
    while (n-- > 0)
        a = (b += a) - a;
    return a;
    }
}
