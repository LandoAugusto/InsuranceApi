using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApi.Core.Infrastructure.Http
{
    public class RawRequest : BaseRequest
    {
        public string RequestUri { get; set; }
    }
}
