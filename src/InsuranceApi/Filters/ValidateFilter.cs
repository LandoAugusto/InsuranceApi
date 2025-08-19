using FluentValidation;
using FluentValidation.Results;
using InsuranceApi.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace InsuranceApi.Filters
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="serviceProvider"></param>
    public class ValidationFilter(IServiceProvider serviceProvider) : IAsyncActionFilter
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            foreach (var argument in context.ActionArguments.Values)
            {
                if (argument == null) continue;

                var argumentType = argument.GetType();
                var validatorType = typeof(IValidator<>).MakeGenericType(argumentType);
                var validator = _serviceProvider.GetService(validatorType);

                if (validator is IValidator baseValidator)
                {
                    var validationContext = new ValidationContext<object>(argument);
                    ValidationResult result = await baseValidator.ValidateAsync(validationContext);

                    if (!result.IsValid)
                    {
                        var httpStatusCode = (int)HttpStatusCode.UnprocessableContent;

                        var errors = result.Errors
                       .GroupBy(e => e.PropertyName)
                       .ToDictionary(
                           g => g.Key,
                           g => g.Select(e => e.ErrorMessage).ToArray()
                       );

                        var response = new BaseDataResponseModel<object>
                        {
                            TransactionStatus = new StatusResponseModel
                            {
                                Code = httpStatusCode,
                                Message = errors.ToString(),
                            }
                        };
                        context.Result = new ObjectResult(response)
                        {
                            StatusCode = httpStatusCode
                        };

                        return; 
                    }
                }
            }

            await next(); 
        }
    }
}