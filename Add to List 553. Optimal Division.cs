//Given a list of positive integers, the adjacent integers will perform the float division. For example, [2,3,4] -> 2 / 3 / 4.
//However, you can add any number of parenthesis at any position to change the priority of operations. 
//You should find out how to add parenthesis to get the maximum result, and return the corresponding expression in string format. 
//Your expression should NOT contain redundant parenthesis.
//Example:
//Input: [1000,100,10,2]
//Output: "1000/(100/10/2)"

public class Solution {
    public string OptimalDivision(int[] nums) {
        string result = Convert.ToString(nums[0]);;
        if (nums.Length == 1) {
            return result;
        }
        if (nums.Length == 2) {
            return result + "/" + Convert.ToString(nums[1]);
        }
        result += "/(" + Convert.ToString(nums[1]);
        for (int i = 2; i < nums.Length; ++i) {
            result += "/" + Convert.ToString(nums[i]);
        }
        result += ")";
        return result;
    }
}

//Explanation
//X1/X2/X3/../Xn will always be equal to (X1/X2) * Y, no matter how you place parentheses.
//i.e no matter how you place parentheses, X1 always goes to the numerator and X2 always goes to the denominator.
//Hence you just need to maximize Y. And Y is maximized when it is equal to X3 *..*Xn. 
//So the answer is always X1/(X2/X3/../Xn) = (X1 *X3 *..*Xn)/X2
