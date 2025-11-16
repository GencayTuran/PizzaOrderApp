namespace Application.CustomExceptions
{
    public class ValidationException(IEnumerable<string> errors) : Exception("Validation failed.")
    {
        public List<string> Errors { get; } = [.. errors];
    }
}