using TicTacToe.BoardComponents;

namespace TicTacToe.GameControllers;

internal class PlayerGameController : IGameController
{
    public (int, int) GetNextMoveTargetIndices(Board board)
    {
        while (true)
        {
            Console.WriteLine("What square do you want to play in? (press a number on your numpad)");

            (int, int) targetIndices;
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad7: targetIndices = (0, 0); break;
                case ConsoleKey.NumPad8: targetIndices = (0, 1); break;
                case ConsoleKey.NumPad9: targetIndices = (0, 2); break;
                case ConsoleKey.NumPad4: targetIndices = (1, 0); break;
                case ConsoleKey.NumPad5: targetIndices = (1, 1); break;
                case ConsoleKey.NumPad6: targetIndices = (1, 2); break;
                case ConsoleKey.NumPad1: targetIndices = (2, 0); break;
                case ConsoleKey.NumPad2: targetIndices = (2, 1); break;
                case ConsoleKey.NumPad3: targetIndices = (2, 2); break;
                default:
                    Console.WriteLine("You should press a key on your numpad. Try again.");
                    continue;
            }

            if (!board.AreCellIndicesValid(targetIndices.Item1, targetIndices.Item2))
            {
                throw new InvalidOperationException("keypress generates invalid cell indices");
            }
            if (board.IsCellOccupied(targetIndices.Item1, targetIndices.Item2))
            {
                Console.WriteLine("This cell is already occupied. Choose another one.");
                continue;
            }

            return targetIndices;
        }
    }
}
