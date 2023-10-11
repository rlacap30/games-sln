using Games.Classes;
using Games.CustomExceptions;
using Games.Games.Tennis;
using Games.Interfaces;

namespace Games.Managers
{
    public class GameCreatorManager
    {
        private readonly string selectedGame;
        private readonly Player playerOne;
        private readonly Player playerTwo;

        public GameCreatorManager(string selectedGame,
            Player playerOne,
            Player playerTwo)
        {
            this.selectedGame = selectedGame;
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
        }

        public IGame CreateGame()
        {
            switch (selectedGame)
            {
                case "tennis":
                    return new TennisGame(playerOne, playerTwo);
                default:
                    throw new GameNotAvailableException();
            }
        }
    }
}
