using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
namespace Trucks.Api.Controllers
{
    public class CategoryResultFilterAttribute : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var resultInAction = context.Result as ObjectResult;
            if (resultInAction?.Value == null ||
                resultInAction.StatusCode < 200 ||
                resultInAction.StatusCode >= 300) {
                await next();
                return;
            }
            var mapper = context.HttpContext.RequestServices.GetRequiredService<IMapper>();
            resultInAction.Value = mapper.Map<Dto.CategoryDto>(resultInAction.Value);
            await next();
        }
    }
}
