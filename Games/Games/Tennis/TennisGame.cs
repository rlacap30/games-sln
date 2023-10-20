using Games.Classes;
using Games.CustomExceptions;
using Games.Interfaces;

namespace Games.Games.Tennis
{
    public class TennisGame : IGame
    {
        private readonly Player playerOne;
        private readonly Player playerTwo;
        private string currentPlayer;
        private readonly IScoringSystem scoringSystem; 

        public TennisGame(Player playerOne,
            Player playerTwo)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
            currentPlayer = new Random().Next(1, 3) == 1 ? playerOne.Name : playerTwo.Name;
            scoringSystem = new TennisScoringSystem();
        }

        public void StartGame()
        {
            Console.WriteLine($"Game Started, {currentPlayer} will start the game");
            playerOne.SetPlayerPoints(0);
            playerTwo.SetPlayerPoints(0);
            scoringSystem.DisplayBaseScore(playerOne, playerTwo);
        }

        public void PlayGame()
        {
            while (!scoringSystem.IsGameOver(playerOne.Points, playerTwo.Points))
            {               
                if (currentPlayer == playerOne.Name)
                {
                    var currentPoints = playerOne.Points + scoringSystem.AssignPoint();
                    playerOne.SetPlayerPoints(currentPoints);
                    currentPlayer = playerTwo.Name;
                }
                else if (currentPlayer == playerTwo.Name)
                {
                    var currentPoints = playerTwo.Points + scoringSystem.AssignPoint();
                    playerTwo.SetPlayerPoints(currentPoints);
                    currentPlayer = playerOne.Name;
                }
                else
                {
                    throw new InvalidUserException($"User {currentPlayer} does not exist");
                }

                Console.WriteLine(scoringSystem.GetScoreStatus(playerOne, playerTwo));
            }

            Console.WriteLine($"WINNER {scoringSystem.DisplayScore(playerOne, playerTwo)}");

        }
    }
}
