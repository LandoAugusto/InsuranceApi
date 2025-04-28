using Newtonsoft.Json;

namespace Warranty.Mock.Api.Models.Base
{
    public  class BaseResponse
    {
        [JsonProperty("cd_retorno")]
        public int? cd_retorno { get; set; }

        [JsonProperty("nm_retorno")]
        public string? nm_retorno { get; set; }
    }
}
