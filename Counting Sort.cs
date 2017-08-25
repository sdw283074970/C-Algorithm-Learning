//计数排序，在时间复杂度=O(n)时快于比较排序
//算法思想步骤：
//1 将输入元素按照出现频率计数，按照0~99或类似的先定顺序输入进一个List<int>里；
//2 遍历扫描List<int>，对应键k为需排序的对象，键值List[k]为频数，添加每个键值不为0的键到一个新的List2<int>；
//3 List[k]频数--，键k--；
//转换List2<int>为需要的输出类型。

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int n = Convert.ToInt32(Console.ReadLine());
        int[] s = Array.ConvertAll<string, int>(Console.ReadLine().Split(' '), Int32.Parse);
        List<int> list = new List<int>();
        List<int> lt = new List<int>();
        for (int i = 0; i < 100; i++) {
            list.Add(0);
        }
        for (int j = 0; j < n; j++) {
            list[s[j]] += 1;
        }
        for (int k = 0; k < list.Count; k++) {
            if (list[k] != 0) {
                lt.Add(k);
                list[k] -= 1;
                k -= 1;
            }
        }
        int[] intresult = lt.ToArray();
        string[] stringresult = intresult.Select(i=>i.ToString()).ToArray();
        string result = String.Join(" ", stringresult);
        Console.WriteLine(result);
    }
}
