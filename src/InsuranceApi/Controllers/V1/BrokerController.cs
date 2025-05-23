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
    /// <param name="brokerAppService"></param>
    public class BrokerController(IBrokerAppService brokerAppService) : BaseController
    {
        private readonly IBrokerAppService _brokerAppService = brokerAppService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="legacyCode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-user-broker/{legacyCode}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<BrokerModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserBrokerAsync(int legacyCode)
        {
            var response = await _brokerAppService.GetByIdAsync(legacyCode, Core.Entities.Enumerators.RecordStatusEnum.Ativo);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="brokerId"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("get-broker-id/{brokerId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<BrokerModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(int brokerId)
        {
            var response = await _brokerAppService.GetByIdAsync(brokerId);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("get-broker-name")]
        [ProducesResponseType(typeof(BaseDataResponseModel<BrokerModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<BrokerModel>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<BrokerModel>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            var response = await _brokerAppService.GetByNameAsync(name);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
    }
}
