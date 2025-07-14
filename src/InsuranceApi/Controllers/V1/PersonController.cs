using InsuranceApi.Application.Interfaces;
using InsuranceApi.Controllers.V1.Base;
using InsuranceApi.Core.Model;
using InsuranceApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApi.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="personAppService"></param>
    public class PersonController(IPersonAppService personAppService) : BaseController
    {
        private readonly IPersonAppService _personAppService = personAppService;

       /// <summary>
       /// 
       /// </summary>
       /// <param name="documentTypeId"></param>
       /// <param name="document"></param>
       /// <returns></returns>
        [HttpGet]
        [Route("get-person-by-document/{documentTypeId}/{document}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<PersonModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByDocumentAsync(int documentTypeId, string document)
        {
            var response = await _personAppService.GetByDocumentAsync(documentTypeId, document);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
    }
}
