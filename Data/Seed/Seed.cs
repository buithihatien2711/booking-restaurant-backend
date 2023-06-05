using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using backend.Data.Entities;

namespace backend.Data.Seed
{
    public class Seed
    {
        public static void SeedService(DataContext context) {
            if(context.TypeOfServices.Any()) return;
            
            context.TypeOfServices.Add(new TypeOfService(1, "Buffet"));
            context.TypeOfServices.Add(new TypeOfService(2, "Gọi món"));

            context.SaveChanges();
        }

        public static void SeedCuisine(DataContext context) {
            if(context.TypeOfCuisines.Any()) return;
            
            context.TypeOfCuisines.Add(new TypeOfCuisine(1, "Lẩu"));
            context.TypeOfCuisines.Add(new TypeOfCuisine(2, "Nướng"));
            context.TypeOfCuisines.Add(new TypeOfCuisine(3, "Lẩu-Nướng"));
            context.TypeOfCuisines.Add(new TypeOfCuisine(4, "Quán chay"));
            context.TypeOfCuisines.Add(new TypeOfCuisine(5, "Quán nhậu"));
            context.TypeOfCuisines.Add(new TypeOfCuisine(6, "Món việt"));
            context.TypeOfCuisines.Add(new TypeOfCuisine(7, "Món ăn miền Bắc"));
            context.TypeOfCuisines.Add(new TypeOfCuisine(8, "Món ăn miền Trung"));
            context.TypeOfCuisines.Add(new TypeOfCuisine(9, "Món ăn miền Nam"));
            context.TypeOfCuisines.Add(new TypeOfCuisine(10, "Món Nhật"));
            context.TypeOfCuisines.Add(new TypeOfCuisine(11, "Món Hàn"));
            context.TypeOfCuisines.Add(new TypeOfCuisine(12, "Món Thái"));
            context.TypeOfCuisines.Add(new TypeOfCuisine(13, "Món Trung"));
            context.TypeOfCuisines.Add(new TypeOfCuisine(14, "Món Á"));
            context.TypeOfCuisines.Add(new TypeOfCuisine(15, "Món Âu"));
            context.TypeOfCuisines.Add(new TypeOfCuisine(16, "Món Ý"));
            context.TypeOfCuisines.Add(new TypeOfCuisine(17, "Món Mỹ"));
            context.TypeOfCuisines.Add(new TypeOfCuisine(18, "Món Pháp"));
            context.TypeOfCuisines.Add(new TypeOfCuisine(19, "Món Singapore"));
            context.TypeOfCuisines.Add(new TypeOfCuisine(20, "Món Nga"));
            context.TypeOfCuisines.Add(new TypeOfCuisine(21, "Đặc sản"));
            context.TypeOfCuisines.Add(new TypeOfCuisine(22, "Hải sản"));

            context.SaveChanges();
        }

        public static void SeedSuitability(DataContext context) {
            if(context.Suitabilities.Any()) return;
            
            context.Suitabilities.Add(new Suitability(1, "Văn phòng"));
            context.Suitabilities.Add(new Suitability(2, "Cặp đôi"));
            context.Suitabilities.Add(new Suitability(3, "Bạn bè"));
            context.Suitabilities.Add(new Suitability(4, "Gia đình"));
            context.Suitabilities.Add(new Suitability(5, "Văn phòng"));
            context.SaveChanges();
        }

        public static void SeedExtraService(DataContext context) {
            if(context.ExtraServices.Any()) return;
            
            context.ExtraServices.Add(new ExtraService(){Id = 1, Name = "Chỗ để xe"});
            context.ExtraServices.Add(new ExtraService(){Id = 2, Name = "Phòng riêng"});
            context.ExtraServices.Add(new ExtraService(){Id = 3, Name = "Có xuất hóa đơn"});
            context.ExtraServices.Add(new ExtraService(){Id = 4, Name = "Karaoke"});
            context.ExtraServices.Add(new ExtraService(){Id = 5, Name = "Màn chiếu"});
            context.ExtraServices.Add(new ExtraService(){Id = 6, Name = "Wifi"});
            context.ExtraServices.Add(new ExtraService(){Id = 7, Name = "Thanh toán thẻ"});
            context.ExtraServices.Add(new ExtraService(){Id = 8, Name = "Trang trí sự kiện"});
            context.ExtraServices.Add(new ExtraService(){Id = 9, Name = "Bàn ngoài trời"});
            context.ExtraServices.Add(new ExtraService(){Id = 10, Name = "Khu vui chơi trẻ em"});
            context.SaveChanges();
        }

        public static void SeedRole(DataContext context) {
            if(context.Roles.Any()) return;
            
            context.Roles.Add(new Role(1, "Admin"));
            context.Roles.Add(new Role(2, "Owner"));
            context.Roles.Add(new Role(3, "User"));
            context.SaveChanges();
        }

        public static void SeedRestaurants(DataContext context) {
            if(context.Restaurants.Any()) return;
            
            var restaurantList = new List<Restaurant>();

            for (int i = 0; i < 300; i++)
            {
                Random random = new Random();
                PriceRange[] priceRanges = (PriceRange[])Enum.GetValues(typeof(PriceRange));
                PriceRange randomPriceRange = priceRanges[random.Next(priceRanges.Length)];

                var restaurant = new Restaurant
                {
                    Id = Guid.NewGuid(),
                    Name = "Restaurant " + i,
                    Phone = "123-456-7890",
                    PriceRange = randomPriceRange,
                    Capacity = 50,
                    SpecialDishes = "Special dishes for Restaurant " + i,
                    Introduction = "Introduction for Restaurant " + i,
                    Note = "Note for Restaurant " + i,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    UserId = new Guid("ee475df2-87c9-4cca-f211-08db6510c972"),
                };
                restaurantList.Add(restaurant);
                // context.Add(restaurant);
            }
            context.AddRange(restaurantList);
            context.SaveChanges();
        }
    
        public static void SeedLocation(DataContext context) {
            if(context.Locations.Any()) return;

            List<Guid> restaurantIds = context.Restaurants.Select(r => r.Id).ToList();
            var locationList = new List<Location>();
            for (int i = 0; i < 300; i++)
            {
                var location = new Location
                {
                    Id = Guid.NewGuid(),
                    Address = "Address for Location " + i,
                    WardId = 1,
                    RestaurantId = restaurantIds[i]
                };

                locationList.Add(location);
            }
            context.AddRange(locationList);
            context.SaveChanges();
        }

        public static void SeedCity(DataContext context)
        {
            if (context.Cities.Any()) return;

            var locationText = System.IO.File.ReadAllText("Data\\Seed\\Vietnam-location\\cities.json");
            var cities = JsonSerializer.Deserialize<List<CitySeedDto>>(locationText);
            var cityEntities = new List<City>();

            if(cities == null){
                return;
            }
            foreach (var city in cities)
            {
                cityEntities.Add(new City()
                {
                    Id = Int32.Parse(city.code),
                    Name = city.name
                });
            }
            context.AddRange(cityEntities);
            context.SaveChanges();
        }

        public static void SeedDistrict(DataContext context)
        {
            if (context.Districts.Any()) return;

            var districtText = System.IO.File.ReadAllText("Data\\Seed\\Vietnam-location\\districts.json");
            var districts = JsonSerializer.Deserialize<List<DistrictSeedDto>>(districtText);
            var districtEntities = new List<District>();

            if(districts == null){
                return;
            }
            foreach (var district in districts)
            {
                districtEntities.Add(new District()
                {
                    Id = Int32.Parse(district.code),
                    Name = district.name,
                    CityId = Int32.Parse(district.parent_code)
                });
            }
            context.AddRange(districtEntities);
            context.SaveChanges();
        }

        public static void SeedWard(DataContext context)
        {
            if (context.Wards.Any()) return;

            var wardText = System.IO.File.ReadAllText("Data\\Seed\\Vietnam-location\\wards.json");
            var wards = JsonSerializer.Deserialize<List<WardSeedDto>>(wardText);
            var wardEntities = new List<Ward>();

            if(wards == null){
                return;
            }
            foreach (var ward in wards)
            {
                wardEntities.Add(new Ward()
                {
                    Id = Int32.Parse(ward.code),
                    Name = ward.name,
                    DistrictID = Int32.Parse(ward.parent_code)
                });
            }
            context.AddRange(wardEntities);
            context.SaveChanges();
        }
    }

    public class CitySeedDto
    {
        public string? name { get; set; }
        
        public string? code { get; set; }

        public string? slug { get; set; }
        
        public string? type { get; set; }
        
        public string? name_with_type { get; set; }
    }

    public class DistrictSeedDto
    {
        public string? name { get; set; }

        public string? type { get; set; }
        
        public string? slug { get; set; }
        
        public string? name_with_type { get; set; }
        
        public string? path { get; set; }
        
        public string? path_with_type { get; set; }
        
        public string? code { get; set; }
        
        public string? parent_code { get; set; }
    }

    public class WardSeedDto
    {
        public string? name { get; set; }

        public string? type { get; set; }
        
        public string? slug { get; set; }
        
        public string? name_with_type { get; set; }
        
        public string? path { get; set; }
        
        public string? path_with_type { get; set; }

        public string? code { get; set; }
        
        public string? parent_code { get; set; }
    }
}