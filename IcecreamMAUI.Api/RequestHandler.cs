using IcecreamMAUI.Shared.Models;

namespace IcecreamMAUI.Api;

public class RequestHandler
{
    public async Task<IResult> HandleRequest<T>(Func<Task<ServiceResult<T>>> serviceCall) where T : class
    {
        var result = await serviceCall();
        return result.ToHttpResponse();
    }
}
