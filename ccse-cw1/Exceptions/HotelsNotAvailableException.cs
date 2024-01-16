namespace ccse_cw1.Exceptions
{
    public class HotelsNotAvailableException : Exception
    {
        public HotelsNotAvailableException()
        { }

        public HotelsNotAvailableException(string message)
            : base(message)
        { }
    }

}
