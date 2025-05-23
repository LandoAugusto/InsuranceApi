using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Models;
using InsuranceApi.Service.Client.Interfaces.Product;

namespace InsuranceApi.Application.Services
{
    internal class VehicleAppService(IVehicleService vehicleService) : IVehicleAppService
    {
        private readonly IVehicleService _vehicleService = vehicleService;
        public async Task<IEnumerable<VehicleBrandModel>?> GetSearchBrandAsync(string name)
        {
            var response = await _vehicleService.GetVehicleBrandAsync(name);
            if (response == null || !response.Any())
            {
                return null;
            }
            return response;
        }

        public async Task<IEnumerable<VehicleModelModel>?> GetVehicleModelAsync(int vehicleBranchId, string? name)
        {
            var response = await _vehicleService.GetVehicleModelAsync(vehicleBranchId,name);
            if (response == null || !response.Any())
            {
                return null;
            }
            return response;
        }

        public async Task<IEnumerable<VehicleVersionModel>?> GetVehicleVersionAsync(int vehicleModelId, string? name)
        {
            var response = await _vehicleService.GetVehicleVersionAsync(vehicleModelId, name);
            if (response == null || !response.Any())
            {
                return null;
            }
            return response;
        }

        public async Task<IEnumerable<VehicleYearModel>?> GetVehicleYearAsync()
        {
            var response = await _vehicleService.GetVehicleYearAsync();
            if (response == null || !response.Any())
            {
                return null;
            }
            return response;
        }
    }
}
