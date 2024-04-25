using System;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        private string currentPlayer = "X";
        private string[,] board = new string[3, 3];

        public MainWindow()
        {
            InitializeComponent();
            InitializeBoard();
            WindowState = WindowState.Maximized; // Teljes képernyős mód
            MinWidth = MinHeight = Width = Height = 300; // Ablak mérete négyzet alakú lesz
        }

        private void InitializeBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = "";
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int row = Grid.GetRow(button);
            int col = Grid.GetColumn(button);

            if (board[row, col] == "")
            {
                board[row, col] = currentPlayer;
                button.Content = currentPlayer;

                if (CheckWin())
                {
                    MessageBox.Show(currentPlayer + " wins!");
                    InitializeBoard();
                    ClearButtons();
                }
                else if (CheckDraw())
                {
                    MessageBox.Show("It's a draw!");
                    InitializeBoard();
                    ClearButtons();
                }
                else
                {
                    currentPlayer = (currentPlayer == "X") ? "O" : "X";
                }
            }
        }

        private bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
                    return true;
            }

            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
                    return true;
            }

            if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
                return true;

            if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
                return true;

            return false;
        }

        private bool CheckDraw()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == "")
                        return false;
                }
            }
            return true;
        }

        private void ClearButtons()
        {
            foreach (var child in gameGrid.Children)
            {
                if (child is Button button)
                {
                    button.Content = "";
                }
            }
        }
    }
}
