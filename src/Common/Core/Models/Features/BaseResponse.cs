namespace Core.Models.Features;

public class BaseResponse<TResponse> where TResponse : class
{
    public Ulid Id { get; set; } = Ulid.NewUlid();
    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public string? Detail { get; set; }
    public TResponse? Data { get; set; }

    public static BaseResponse<TResponse> Success(TResponse data)
    {
        return new BaseResponse<TResponse>
        {
            IsSuccess = true,
            StatusCode = 200,
            Message = "Success",
            Data = data
        };
    }

    public static BaseResponse<TResponse> Failure(int statusCode, string detail)
    {
        return new BaseResponse<TResponse>
        {
            IsSuccess = false,
            StatusCode = statusCode,
            Message = "Failure",
            Detail = detail
        };
    }
}
