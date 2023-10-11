using Games.Classes;

namespace Games.Interfaces
{
    public interface IScoringSystem
    {
        int AssignPoint();
        bool IsAdvantage(int playerOnePoints, int playerTwoPoints);
        bool IsBaseScore(int playerOnePoints, int playerTwoPoints);
        string DisplayBaseScore(Player playerOne, Player playerTwo);
        bool IsDeuce(int playerOnePoints, int playerTwoPoints);
        bool IsGameOver(int playerOnePoints, int playerTwoPoints);
        string DisplayScore(Player playerOne, Player playerTwo);
    }
}
