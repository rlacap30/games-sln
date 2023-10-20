using Games.Classes;

namespace Games.Interfaces
{
    public interface IScoringSystem
    {
        int AssignPoint();
        string DisplayBaseScore(Player playerOne, Player playerTwo);
        bool IsGameOver(int playerOnePoints, int playerTwoPoints);
        string DisplayScore(Player playerOne, Player playerTwo);
        string GetScoreStatus(Player playerOne, Player playerTwo);
    }
}
