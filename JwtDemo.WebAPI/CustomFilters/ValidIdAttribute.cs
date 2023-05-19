using JwtDemo.Entities.Abstract;
using JwtDemo.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JwtDemo.WebAPI.CustomFilters;

public class ValidIdAttribute<T> : IActionFilter
    where T : class, IBaseEntity, new()
{
    private readonly IBaseRepository<T> _baseRepository;

    public ValidIdAttribute(IBaseRepository<T> baseRepository)
    {
        _baseRepository = baseRepository;
    }

    public void OnActionExecuted(ActionExecutedContext context) { }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var dictionary = context.ActionArguments
            .Where(x => x.Key == "id")
            .FirstOrDefault();

        int checkedId = (int)dictionary.Value!;

        var entity = _baseRepository.GetByIdAsync(checkedId).Result;
        if (entity is null)
            context.Result = new NotFoundObjectResult($"Id : {checkedId} bulunamadı");
    }
}
