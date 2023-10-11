namespace Games.CustomExceptions
{
    public class GameNotAvailableException : Exception
    {
        public GameNotAvailableException()
        {
        }

        public GameNotAvailableException(string message) : base(message)
        {
        }
    }
}
