namespace ccse_cw1.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException()
        { }

        public UserNotFoundException(string message)
            : base(message)
        { }
    }

}
