namespace Games.CustomExceptions
{
    public class InvalidUserException : Exception
    {
        public InvalidUserException()
        {
        }

        public InvalidUserException(string message) : base(message)
        {
        }
    }
}
