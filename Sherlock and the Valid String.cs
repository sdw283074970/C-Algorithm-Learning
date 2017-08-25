//Sherlock considers a string, s , to be valid if either of the following conditions are satisfied:
//1. All characters in s have the same exact frequency (i.e., occur the same number of times). For example, "aabbcc" is valid, 
//but baaccd is not valid.
//2. Deleting exactly 1 character from  will result in all its characters having the same frequency. For example, 
//"aabbccc" and "aabbc" are valid because all their letters will have the same frequency if we remove 1 occurrence of c, 
//but "abcccc" is not valid because we'd need to remove 3 characters.
//Sample Input 0
//aabbcd
//Sample Output 0
//NO

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static string isValid(string s){
        // Complete this function
        string isV = "NO";
        bool chance = true;
        List<int> list = new List<int>();
        List<int> list2 = new List<int>();
        for (int i = 0; i < 26; i ++) {
            list.Add(0);
        }
        for (int j = 0; j < s.Length; j++) {
            list[(int)(s[j]) - 97] += 1;
        }
        foreach (int q in list) {
            if (q != 0) {
                list2.Add(q);
            }
        }
        int[] array = list2.ToArray();
        Array.Sort(array);
        if (array.Length == 1) {
            isV = "YES";
        }
        else {
            for (int k = 0; k < array.Length - 2; k ++) {
                if (array[k + 2] - array[k] == 1 && chance == true) {
                    isV = "YES";
                    chance = false;
                }
                else if (array[k] == array[k + 2]) {
                    isV = "YES";
                }
                else {
                    isV = "NO";
                    k = array.Length;
                }
            }
            if (array[0] == 1 && array[0] != array[1]) {
                isV = "YES";
            }
        }
        return isV;
    }

    static void Main(String[] args) {
        string s = Console.ReadLine();
        string result = isValid(s);
        Console.WriteLine(result);
    }
}
