namespace ValueCheck;

public static class ValidationCheckExtensions
{
    public static ValidationCheck<T> WithError<T>(this ValidationCheck<T> check, string message)
        => !string.IsNullOrWhiteSpace(message)
            ? check.OnFailure(_ => Error.WithMessage(message))
            : check;
}