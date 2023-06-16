using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs.LocationDTO;

namespace backend.Services.LocationService
{
    public interface ILocationService
    {
        List<CityDto>? GetAllCity();

        List<DistrictDto>? GetDistrictsOfCity(int cityId);

        List<WardDto>? GetWardsOfDistrict(int districtId);
    }
}