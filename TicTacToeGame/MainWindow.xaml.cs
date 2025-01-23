using System.Windows;
using System.Windows.Controls;

namespace TicTacToeGame
{
    public partial class MainWindow : Window
    {
        private string currentPlayer = "X";
        private Button[,] buttons;

        public MainWindow()
        {
            InitializeComponent();
            buttons = new Button[,] { { btn00, btn01, btn02 }, { btn10, btn11, btn12 }, { btn20, btn21, btn22 } };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (string.IsNullOrEmpty(button.Content as string))
            {
                button.Content = currentPlayer;
                if (CheckWinner())
                {
                    MessageBox.Show($"Player {currentPlayer} Wins!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                    ResetGame();
                    return;
                }

                if (IsDraw())
                {
                    MessageBox.Show("It's a Draw!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                    ResetGame();
                    return;
                }

                currentPlayer = (currentPlayer == "X") ? "O" : "X";
            }
        }

        private bool CheckWinner()
        {
            // Check rows, columns, and diagonals
            for (int i = 0; i < 3; i++)
            {
                if (buttons[i, 0].Content?.ToString() == currentPlayer &&
                    buttons[i, 1].Content?.ToString() == currentPlayer &&
                    buttons[i, 2].Content?.ToString() == currentPlayer)
                    return true;

                if (buttons[0, i].Content?.ToString() == currentPlayer &&
                    buttons[1, i].Content?.ToString() == currentPlayer &&
                    buttons[2, i].Content?.ToString() == currentPlayer)
                    return true;
            }

            if (buttons[0, 0].Content?.ToString() == currentPlayer &&
                buttons[1, 1].Content?.ToString() == currentPlayer &&
                buttons[2, 2].Content?.ToString() == currentPlayer)
                return true;

            if (buttons[0, 2].Content?.ToString() == currentPlayer &&
                buttons[1, 1].Content?.ToString() == currentPlayer &&
                buttons[2, 0].Content?.ToString() == currentPlayer)
                return true;

            return false;
        }

        private bool IsDraw()
        {
            foreach (var btn in buttons)
            {
                if (string.IsNullOrEmpty(btn.Content as string))
                    return false;
            }
            return true;
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            ResetGame();
        }

        private void ResetGame()
        {
            foreach (var btn in buttons)
            {
                btn.Content = "";
            }
            currentPlayer = "X";
        }
    }
}
