using Games.Classes;

namespace Games.Interfaces
{
    public interface IScoringSystem
    {
        int AssignPoint();
        bool IsGameOver(int playerOnePoints, int playerTwoPoints);
        string GetScoreStatus(Player playerOne, Player playerTwo);
    }
}
