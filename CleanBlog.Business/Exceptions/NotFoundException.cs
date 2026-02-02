namespace CleanBlog.Business.Exceptions;

public class NotFoundException(string message="Object is not found"):Exception(message)
{
}
