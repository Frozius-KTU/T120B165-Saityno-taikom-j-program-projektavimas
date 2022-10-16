namespace CarPartsShop;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class CarPartsShopExceptionAttribute : Attribute
{
    public int StatusCode { get; }
    public string? ErrorCode { get; }
    public string? Message { get; set; }

    public CarPartsShopExceptionAttribute(int statusCode, string errorCode)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
    }
        
    public CarPartsShopExceptionAttribute(int statusCode)
    {
        StatusCode = statusCode;
    }
}

