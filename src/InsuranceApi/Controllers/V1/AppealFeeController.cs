using InsuranceApi.Application.Interfaces;
using InsuranceApi.Controllers.V1.Base;
using InsuranceApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApi.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="appealFeeService"></param>
    /// <param name="borrowerAppealFeeAppService"></param>
    public class AppealFeeController(IAppealFeeAppService appealFeeService, IBorrowerAppealFeeAppService borrowerAppealFeeAppService) : BaseController
    {

        private readonly IAppealFeeAppService _appealFeeService = appealFeeService;
        private readonly IBorrowerAppealFeeAppService _borrowerAppealFeeAppService = borrowerAppealFeeAppService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("get-appealFee")]
        [ProducesResponseType(typeof(BaseDataResponseModel<AppealFeeModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<AppealFeeModel>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListAsync(AppealFeeFilterModel request)
        {
            var response = await _appealFeeService.ListAsync(request);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }



        /// <summary>
        ///  Consulta todos os corretores ativos
        /// </summary>
        /// <remarks>
        /// remark goes here.
        /// </remarks>
        /// <param name="id">Required </param>
        /// <return>Returns comment</return>
        /// <response code="200">Ok</response>        
        [HttpPost]
        [Route("get-appealfee-borrower")]
        [ProducesResponseType(typeof(BaseDataResponseModel<BorrowerAppealFeeModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<BorrowerAppealFeeModel>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<BorrowerAppealFeeModel>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync(BorrowerAppealFeeFilterModel request)
        {
            var response = await _borrowerAppealFeeAppService.ListAsync(request);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
    }
}
