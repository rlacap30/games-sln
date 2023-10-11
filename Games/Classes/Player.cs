using Games.CustomExceptions;

namespace Games.Classes
{
    public class Player
    {
        public string Name { get; private set; }
        public int Points { get; private set; }

        public Player(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new InvalidInputException("Please provide a valid name");

            Name = name;
        }

        public void SetPlayerPoints(int points)
        {
            if (points < 0)
                throw new InvalidInputException("Points cannot be negative");

            Points = points;   
        }
    }
}
