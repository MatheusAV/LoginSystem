using LoginSystem.Domain.Exceptions.LoginSystem.Domain.Exceptions;

namespace LoginSystem.Domain.Exceptions
{
    public static class AssertionConcern
    {
        public static void AssertArgumentNotEmpty(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException(message);
        }

        public static void AssertArgumentLength(string value, int maxLength, string message)
        {
            if (value?.Length > maxLength)
                throw new DomainException(message);
        }

        public static void AssertArgumentNotNull(object obj, string message)
        {
            if (obj == null)
                throw new DomainException(message);
        }
    }
}
