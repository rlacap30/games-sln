using Games.Classes;
using Games.CustomExceptions;
using Games.Managers;

string selectedGame = "tennis";

try
{
    Player playerOne = new Player("Test");
    Player playerTwo = new Player("Test_Two");
    
    GameCreatorManager gameCreator = new GameCreatorManager(selectedGame, playerOne, playerTwo);
    var game = gameCreator.CreateGame();

    game.StartGame();
    game.PlayGame();
}
catch (InvalidInputException ex)
{
    Console.WriteLine(ex.Message);
}
catch (GameNotAvailableException)
{
    Console.WriteLine($"Game {selectedGame} is not available");
}
catch (InvalidUserException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine("Unexpected error. Contact customer support.");
}

