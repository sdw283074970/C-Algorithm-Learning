// Problem discription: https://leetcode.com/problems/game-of-life/description/
// This version is temp, unfixed

public class Solution {
    public void GameOfLife(int[,] board) {
        for (int i = 0; i < board.GetLength(0); i++) {
            for (int j = 0; j < board.GetLength(1); j++) {
                if (liveNeighbors(board, i, j) < 2) {
                    board[i , j] = 0;
                }
                else if ((liveNeighbors(board, i, j) == 2 || liveNeighbors(board, i, j) == 3) && board[i, j] == 1) {
                    board[i, j] = 1;
                }
                else if (liveNeighbors(board, i, j) == 3 && board[i, j] == 1) {
                    board[i, j] = 1;
                }
                else if (liveNeighbors(board, i, j) > 3) {
                    board[i, j] = 0;
                }
                else {
                    board[i, j] = 0;
                }
            }
        }
    }
    public int liveNeighbors(int[,] board, int i, int j) {
        int cells = 0;
        if (i > 0 && i < board.GetLength(0) - 1 && j > 0 && j < board.GetLength(1) - 1) {
            cells = board[i - 1, j - 1] + board[i - 1, j] + board[i - 1, j + 1] 
                + board[i, j - 1] + board[i, j + 1]
                + board[i + 1, j - 1] + board[i + 1, j] + board[i + 1, j + 1];
        }
        else if (i == 0 && j == 0) {
            cells = board[1, 0] + board[1, 1] + board[0, 1];
        }
        else if (i == 0 && j == board.GetLength(1) - 1) {
            cells = board[0, board.GetLength(1) - 2] + board[1, board.GetLength(1) - 2] + board[1, board.GetLength(1) - 1];
        }
        else if (i == board.GetLength(0) - 1 && j == 0) {
            cells = board[board.GetLength(0) - 2, 0] + board[board.GetLength(0) - 2, 1] + board[board.GetLength(0) - 1, 1];
        }
        else if (i == board.GetLength(0) - 1 && j == board.GetLength(1) - 1) {
            cells = board[board.GetLength(0) - 1, board.GetLength(1) - 2] + board[board.GetLength(0) - 2, board.GetLength(1) - 2]
                + board[board.GetLength(0) - 2, board.GetLength(1) - 1];
        }
        else if (i == 0) {
            cells = board[i, j - 1] + board[i, j + 1] + board[i + 1, j - 1] + board[i + 1, j] + board[i + 1, j + 1];
        }
        else if (i == board.GetLength(0) - 1) {
            cells = board[i - 1, j - 1] + board[i - 1, j] + board[i - 1, j + 1] + board[i, j - 1] + board[i, j + 1];
        }
        else if (j == 0) {
            cells = board[i - 1, j] + board[i - 1, j + 1] + board[i, j + 1] + board[i + 1, j] + board[i + 1, j + 1];
        }
        else if (j == board.GetLength(1) - 1) {
            cells = board[i - 1, j - 1] + board[i - 1, j] + board[i, j - 1] + board[i + 1, j - 1] + board[i + 1, j];
        }
        return cells;
    }
}
