﻿namespace News_Portal.Exceptions
{
    public class UnauthorizedAccessException:Exception
    {
        public UnauthorizedAccessException(string message):base(message) { }
    }
}
