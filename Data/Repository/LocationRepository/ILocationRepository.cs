using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Entities;

namespace backend.Data.Repository.LocationRepository
{
    public interface ILocationRepository
    {
        List<City>? GetAllCity();

        List<District>? GetDistrictsOfCity(int cityId);

        List<Ward>? GetWardsOfDistrict(int districtId);
    }
}