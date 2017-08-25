//Given a list of unsorted integers A = {a1, a2, a3, ... , an}.
//Can you find the pair of elements that have the smallest absolute difference between them? 
//If there are multiple pairs, find them all.
//Sample Input #1
//10
//-20 -3916237 -357920 -3620601 7374819 -7330761 30 6246457 -6461594 266854 
//Sample Output #1
//-20 30

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int n = Convert.ToInt32(Console.ReadLine());
        int[] s = Array.ConvertAll<string, int>(Console.ReadLine().Split(' '), Int32.Parse);
        Array.Sort(s);
        List<int> list = new List<int>();
        List<int> list2 = new List<int>();
        for (int i = 0; i < n - 1; i++) {
            list.Add(Math.Abs(s[i] - s[i + 1]));
        }
        int[] sortedlist = list.ToArray();
        Array.Sort(sortedlist);
        for (int j = 0; j < list.Count; j++) {
            if (list[j] == sortedlist[0]) {
                list2.Add(s[j]);
                list2.Add(s[j + 1]);
            }
        }
        int[] sortedlist2 =list2.ToArray();
        Array.Sort(sortedlist2);
        string[] string_Array = sortedlist2.Select(i=>i.ToString()).ToArray();
        string result = String.Join(" ", string_Array);
        Console.WriteLine(result);
    }
}
