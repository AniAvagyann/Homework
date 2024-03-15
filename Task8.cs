using System;

public class Chessboard
{
    private string[,] board;
    private int[,] moveScores;
    private int currentRow;
    private int currentColumn;

    public Chessboard()
    {
        board = new string[8, 8];
        moveScores = new int[8, 8];
        InitializeBoard();
        InitializeMoveScores();
        currentRow = 0;
        currentColumn = 0;
    }

    private void InitializeBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                board[i, j] = "0 ";
            }
        }
    }

    private void InitializeMoveScores()
    {
        int[,] temp =
        {
            {2, 3, 4, 4, 4, 4, 3, 2},
            {3, 4, 6, 6, 6, 6, 4, 3},
            {4, 6, 8, 8, 8, 8, 6, 4},
            {4, 6, 8, 8, 8, 8, 6, 4},
            {4, 6, 8, 8, 8, 8, 6, 4},
            {4, 6, 8, 8, 8, 8, 6, 4},
            {3, 4, 6, 6, 6, 6, 4, 3},
            {2, 3, 4, 4, 4, 4, 3, 2}
        };

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                moveScores[i, j] = temp[i, j];
            }
        }
    }

    public void PrintBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write(board[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public void PlaceKnight(int row, int column)
    {
        currentRow = row;
        currentColumn = column;
        board[row, column] = "K ";
    }

    public void MoveKnight()
    {
        int minScore = int.MaxValue;
        int minRow = 0;
        int minColumn = 0;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (IsKnightMoveValid(i, j) && moveScores[i, j] < minScore)
                {
                    minScore = moveScores[i, j];
                    minRow = i;
                    minColumn = j;
                }
            }
        }

        currentRow = minRow;
        currentColumn = minColumn;
        board[minRow, minColumn] = "K ";
    }

    private bool IsKnightMoveValid(int targetRow, int targetColumn)
    {
        int rowDiff = Math.Abs(targetRow - currentRow);
        int colDiff = Math.Abs(targetColumn - currentColumn);

        return (rowDiff == 2 && colDiff == 1) || (rowDiff == 1 && colDiff == 2);
    }

    public bool HasValidMoves()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (IsKnightMoveValid(i, j))
                {
                    return true;
                }
            }
        }
        return false;
    }
}

public class ChessGame
{
    public static void Main()
    {
        Chessboard chessboard = new Chessboard();
        chessboard.PrintBoard();

        bool continueGame = true;

        do
        {
            Console.Write("Enter the row for the knight (1-8): ");
            int row = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Enter the column for the knight (1-8): ");
            int col = int.Parse(Console.ReadLine()) - 1;

            if (row < 0 || row > 7 || col < 0 || col > 7)
            {
                Console.WriteLine("Invalid input. Row and column should be between 1 and 8.");
                continue;
            }

            chessboard.PlaceKnight(row, col);
            chessboard.PrintBoard();

            if (!chessboard.HasValidMoves())
            {
                Console.WriteLine("No more valid moves. Game over.");
                continueGame = false;
                break;
            }

            Console.Write("Move the knight to the next valid position? (y/n): ");
            string answer = Console.ReadLine().ToLower();

            if (answer != "y")
            {
                continueGame = false;
                break;
            }

            chessboard.MoveKnight();
            chessboard.PrintBoard();

        } while (continueGame);
    }
}
