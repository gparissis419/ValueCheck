namespace ValueCheck;

public class ValidationCheck<T>
{
    public T? Value { get; init; }
    public Error? Error { get; init; }
    public bool Passed => Error == null;

    public ValidationCheck(T? value)
    {
        Value = value;
        Error = null;
    }

    public ValidationCheck(Error error)
    {
        Value = default!;
        Error = error;
    }

    internal ValidationCheck<T> OnFailure(Func<Error, ValidationCheck<T>> f)
        => Passed ? this : f(Error!);

    public static implicit operator ValidationCheck<T>(T? value) => new(value);
    public static implicit operator ValidationCheck<T>(Error error) => new(error);
}