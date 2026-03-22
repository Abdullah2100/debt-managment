using business.Services.Implement;

namespace business.Util;

public class General
{
    public static DateTime GenerateDateTime(EnTokenMode mode)
    {
        var datetime = mode switch
        {
            EnTokenMode.AccessToken => DateTime.Now.AddHours(1),
            _ => DateTime.Now.AddDays(30)
        };
        return datetime;
    }
}