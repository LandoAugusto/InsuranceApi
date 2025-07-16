using InsuranceApi.Application.Interfaces;
using InsuranceApi.Controllers.V1.Base;

using InsuranceApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApi.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="borrowerAppService"></param>
    public class BorrowerController(IBorrowerAppService borrowerAppService) : BaseController
    {
        private readonly IBorrowerAppService _borrowerAppService = borrowerAppService;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="brokerId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-borrower/{brokerId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<BorrowerModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(int brokerId, string name)
        {
            var response = await _borrowerAppService.ListAsync(brokerId, name, Core.Entities.Enumerators.RecordStatusEnum.Ativo);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="brokerId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-taker/{brokerId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<BorrowerModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTakerAsync(int brokerId, string? name)
        {
            var response = await _borrowerAppService.ListAsync(brokerId, name);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
    }
}
