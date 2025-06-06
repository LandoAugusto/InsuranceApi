﻿using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface IBrokerAppService
    {
        Task<BrokerModel?> GetByIdAsync(int? brokerId, RecordStatusEnum recordStatus);
        Task<BrokerModel?> GetByIdAsync(int brokerId);
        Task<IEnumerable<BrokerModel>?> GetByNameAsync(string name);
    }
}
