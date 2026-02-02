using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CleanBlog.Business.Dtos.ResultDtos;

public class ResultDto
{
    public bool IsSuccedd { get; set; }
    public int StatusCode { get; set; }
    public string Message { get; set; }

    public ResultDto()
    {
        IsSuccedd = true;
        StatusCode = 200;
        Message = "Successfully";
    }

    public ResultDto(string message) : this()
    {
        Message = message;
    }

    public ResultDto(string message, int statusCode) : this(message)
    {
        StatusCode = statusCode;
    }

    public ResultDto(string message, int statusCode, bool isSuccedd) : this(message, statusCode)
    {
        IsSuccedd |= isSuccedd;
    }

}

public class ResultDto<T>:ResultDto
{
    public T? Data { get; set; }

    public ResultDto() : base()
    {

    }

    public ResultDto(T data) : this()
    {
        Data = data;
    }

    public ResultDto(string message,T data) : base(message)
    {
        Data = data;
    }

    public ResultDto(string message, T data,int statusCode) : base(message,statusCode)
    {
        Data = data;
    }

    public ResultDto(string message, T data, int statusCode,bool isSuccedd) : base(message,statusCode,isSuccedd)
    {
        Data = data;
    }
}
