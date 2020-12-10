using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Trucks.Api.ControllerFilters
{
    public class TruckResultFilterAttribute : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var resultFromAction = context.Result as ObjectResult;
            if (resultFromAction?.Value == null ||
                resultFromAction.StatusCode < 200 ||
                resultFromAction.StatusCode >= 300) {
                await next();
                return;
            }
            var mapper = context.HttpContext.RequestServices.GetRequiredService<IMapper>();
            resultFromAction.Value = mapper.Map<Dto.TruckDto>(resultFromAction.Value);
            await next();
        }
    }
}
