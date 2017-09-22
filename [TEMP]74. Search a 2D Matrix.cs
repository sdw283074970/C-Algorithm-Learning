//Problem description: https://leetcode.com/problems/search-a-2d-matrix/description/

public class Solution {
    public bool SearchMatrix(int[,] matrix, int target) {
        if (matrix == null || matrix.GetLength(0) < 1 || matrix.GetLength(1) < 1) {
            return false;
        }
        int i = matrix.GetLength(0) - 1;
        int j = 0;
        while (i >= 0 && j < matrix.GetLength(1)) {
            if (matrix[i, j] == target) {
                return true;
            }
            else if (matrix[i, j] > target) {
                i--;
            }
            else if (matrix[i, j] < target) {
                j++;
            }
        }
        return false;
    }
}
