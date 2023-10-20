﻿using Games.Classes;
using Games.Enums;
using Games.Interfaces;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Games.Tests")]
namespace Games.Games.Tennis
{
    public class TennisScoringSystem : IScoringSystem
    {
        public int AssignPoint()
        {
            return new Random().Next(0, 2);
        }

        internal bool IsBaseScore(int playerOnePoints, int playerTwoPoints)
        {
            if (playerOnePoints < 3 || playerTwoPoints < 3)
                return true;
            return false;
        }

        internal bool IsAdvantage(int playerOnePoints, int playerTwoPoints)
        {
            int playersDifference = GetDifference(playerOnePoints, playerTwoPoints);
            return (playerOnePoints >= 3 && playerTwoPoints >= 3) && playersDifference == 1;
        }

        internal bool IsDeuce(int playerOnePoints, int playerTwoPoints)
        {
            int playersDifference = GetDifference(playerOnePoints, playerTwoPoints);
            return (playerOnePoints >= 3 && playerTwoPoints >= 3) && playersDifference == 0;
        }

        public bool IsGameOver(int playerOnePoints, int playerTwoPoints)
        {
            int playersDifference = GetDifference(playerOnePoints, playerTwoPoints);
            return (playerOnePoints >= 4 || playerTwoPoints >= 4) && playersDifference == 2;
        }

        public string DisplayBaseScore(Player playerOne, Player playerTwo)
        {
            return $"{playerOne.Name} ({Enum.GetName(typeof(TennisPoints), playerOne.Points)} {playerOne.Points} points) - {playerTwo.Name} ({Enum.GetName(typeof(TennisPoints), playerTwo.Points)} {playerTwo.Points} points)";
        }

        public string DisplayScore(Player playerOne, Player playerTwo)
        {
            Player winner = GetWinner(playerOne, playerTwo); 
            Player loser = GetLoser(playerOne, playerTwo);  
            return $"{winner.Name} ({winner.Points} points) - {loser.Name} ({loser.Points} points)";
        }

        public string GetScoreStatus(Player playerOne, Player playerTwo)
        {
            string scoreStatus = string.Empty;
            if (IsBaseScore(playerOne.Points, playerTwo.Points))
                scoreStatus = DisplayBaseScore(playerOne, playerTwo);
            else if (IsDeuce(playerOne.Points, playerTwo.Points))
                scoreStatus = $"DEUCE {playerOne.Name} ({playerOne.Points} points) and {playerTwo.Name} ({playerTwo.Points} points)";
            else if (IsAdvantage(playerOne.Points, playerTwo.Points))
                scoreStatus = $"ADVANTAGE {DisplayScore(playerOne, playerTwo)}";

            return scoreStatus;
        }

        private Player GetWinner(Player playerOne, Player playerTwo)
        {
            return playerOne.Points > playerTwo.Points ? playerOne : playerTwo;
        }

        private Player GetLoser(Player playerOne, Player playerTwo)
        {
            return playerOne.Points < playerTwo.Points ? playerOne : playerTwo;
        }

        private int GetDifference(int playerOnePoints, int playerTwoPoints)
        {
            return Math.Abs(playerOnePoints - playerTwoPoints);
        }
    }
}
