namespace ValueCheck;

public class Error
{
    public string Message { get; init; }

    public Error(string message)
    {
        if (string.IsNullOrWhiteSpace(message))
            throw new Exception("Validation error must have a message.");

        Message = message;
    }

    public static Error WithMessage(string message)
        => new Error(message);
}