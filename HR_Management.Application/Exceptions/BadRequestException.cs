namespace HR_Management.Application.Exceptions;

public class BadRequestException(string message) : ApplicationException(message)
{
}
