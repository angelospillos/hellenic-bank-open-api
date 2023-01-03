namespace HellenicBankOpenAPI.Hellenic.Models;

public class ResponseWrapper<T>
{
    public T Payload { get; set; }
    public Object Errors { get; set; }
}
