namespace business;

public record class Result<T>  
{
    public T Value { get; init; }
    public bool IsSuccess { get; init; }
    public string ErrorMessage { get; init; }
    public int StatusCode { get; init; }
}