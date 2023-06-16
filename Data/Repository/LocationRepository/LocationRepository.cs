using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Entities;

namespace backend.Data.Repository.LocationRepository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly DataContext _context;
        public LocationRepository(DataContext context)
        {
            _context = context;
            
        }
        public List<City>? GetAllCity()
        {
            return _context.Cities.ToList();
        }

        public List<District>? GetDistrictsOfCity(int cityId)
        {
            return _context.Districts.Where(d => d.CityId == cityId).ToList();
        }

        public List<Ward>? GetWardsOfDistrict(int districtId)
        {
            return _context.Wards.Where(w => w.DistrictID == districtId).ToList();
        }
    }
}