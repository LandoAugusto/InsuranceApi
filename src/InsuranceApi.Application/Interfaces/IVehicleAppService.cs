using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface IVehicleAppService
    {
        Task<IEnumerable<VehicleBrandModel>?> GetSearchBrandAsync(string name);
        Task<IEnumerable<VehicleVersionModel>?> GetVehicleVersionAsync(int vehicleModelId, string? name);
        Task<IEnumerable<VehicleModelModel>?> GetVehicleModelAsync(int vehicleBranchId, string? name);
    }
}
