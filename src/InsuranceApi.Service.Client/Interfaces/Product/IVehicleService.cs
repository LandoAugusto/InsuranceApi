using InsuranceApi.Core.Models;

namespace InsuranceApi.Service.Client.Interfaces.Product
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleBrandModel>?> GetVehicleBrandAsync(string name);
        Task<IEnumerable<VehicleModelModel>?> GetVehicleModelAsync(int vehicleBranchId, string? name);
        Task<IEnumerable<VehicleVersionModel>?> GetVehicleVersionAsync(int vehicleModelId, string? name);
    }
}
