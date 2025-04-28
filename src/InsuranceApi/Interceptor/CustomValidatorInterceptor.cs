using Component.Log.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApi.Interceptor
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomValidatorInterceptor(ILogWriter logWriter) : IValidatorInterceptor
    {
        private const string ValidationFailedMessage = "Appeal validation failed";
        private readonly ILogWriter _logWriter = logWriter;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionContext"></param>
        /// <param name="commonContext"></param>
        /// <returns></returns>
        public IValidationContext BeforeAspNetValidation(ActionContext actionContext, IValidationContext commonContext) => commonContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionContext"></param>
        /// <param name="validationContext"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public ValidationResult AfterAspNetValidation(ActionContext actionContext, IValidationContext validationContext, ValidationResult result)
        {
            if (!result.IsValid)
            {
                //var errors = result.Errors.Select(err => new ValidationErrorModel(err)).ToArray();

                //_logWriter.Error(ValidationFailedMessage, errors);
                //actionContext.HttpContext.Items.Add(nameof(ValidationResult), result);
            }

            return result;
        }
    }
}

