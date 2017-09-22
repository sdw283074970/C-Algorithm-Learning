//Problem description: https://leetcode.com/problems/search-a-2d-matrix-ii/description/

public class Solution {
    public bool SearchMatrix(int[,] matrix, int target) {
        if (matrix == null || matrix.GetLength(0) < 1 || matrix.GetLength(1) <1) {
            return false;
        }
        if (matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1] < target) {
            return false;
        }
        int i = 0;
        int j = matrix.GetLength(1) - 1;
        while (i < matrix.GetLength(0) && j >= 0) {
            if (matrix[i, j] == target) {
                return true;
            }
            else if (matrix[i, j] < target) {
                i++;
            }
            else if (matrix[i, j] > target) {
                j--;
            }
        }
        return false;
    }
}
