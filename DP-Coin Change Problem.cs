//钱币找零问题，使用动态规划解决
//给一组钱币C，目标找零钱数N，求一共有多少种找零方法，每种钱币使用次数不限
//核心：深刻理解子问题(subproblem)和状态转移方程
//状态：一种一种加入新钱币参加方法计算，每加入一种为一个状态，新状态=前状态+状态增量，此过程为状态转移
//本问题中前状态为加入新钱币前已求得的换钱方法数量，状态增量为刚好大于新钱币面额的目标钱数减去新钱币面额
//其差值为子问题，即剩下的钱有多少种分解方法，往回查找便知
//本题算法思路如下：
//1.建立一个二维数组dp[i,j]，其意义为当有c[0~i]的钱币面额选择时，换数额为j的钱的方法数
//2.初始化二维数组第一行，即只用第一种钱币的时候各钱数的找零方法，即第一种钱币面额倍数的钱数找零方法为1，其余钱数的找零方法为0
//3.一种一种地添加钱币，当钱数为0的时候找零方法为1，又即目标钱数刚好为新钱币面额时仅有一种新方法那就是使用一张新钱币
//4.建立状态转移方程，当目标钱数小于新钱币面额时，状态不变即找零方法与之前相同；当大于新钱币面额时方法总数等于前状态方法加上用上新钱币的方法(增量)
//5.写出状态转移方程，套入循环中
//6.输出最右下角的dp[i,j]值即为最终换钱方法数

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static long getWays(long n, long[] c){
        // Complete this function
        long [,] dp = new long[c.Length, n + 1];    //dp[i][j]的意义为当有c[0~i]的钱币面额选择时，换数额为j的钱的方法数
        for (int j = 0; c[0] * j <= n; j++) {   //当只用面额为c[0]的钱的时候，换数额j的方法数为有且只有1种
            dp[0, c[0] * j] = 1;
        }
        //计算当仅使用c[0~i]的币种换取j数额的方法
        for (int i = 1; i < c.Length; i++) {    //当使用钱币面额为c[0~i]的时候
            dp[i, 0] = 1;   //0块钱都只有一种
            for (int j = 1; j <= n; j++) {  //从面额1开始直至面额n
                if (j - c[i] >= 0) {    //如果当前钱数大于新加入的面额，方法数为之前的方法数加上j与新钱币的差值钱数的分解方法数
                    dp[i, j] = dp[i - 1, j] + dp[i, j - c[i]];
                }
                else {  //如果目标钱数小于新加入的硬币面额，那么换钱的方法数与加入新钱币之前的方法数一样
                    dp[i, j] = dp[i - 1, j];
                }
            }
        }
        return dp[c.Length - 1, n]; //输出最左下角的数量
    }

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        long n = Convert.ToInt64(tokens_n[0]);
        long m = Convert.ToInt64(tokens_n[1]);
        string[] c_temp = Console.ReadLine().Split(' ');
        long[] c = Array.ConvertAll(c_temp,Int64.Parse);
        // Print the number of ways of making change for 'n' units using coins having the values given by 'c'
        long ways = getWays(n, c);
        Console.WriteLine(ways);
    }
}
