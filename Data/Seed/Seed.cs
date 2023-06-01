using System;
using System.Collections.Generic;
using System.Linq;
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

        public static void SeedRole(DataContext context) {
            if(context.Roles.Any()) return;
            
            context.Roles.Add(new Role(1, "Admin"));
            context.Roles.Add(new Role(2, "Owner"));
            context.Roles.Add(new Role(3, "User"));
            context.SaveChanges();
        }
    }
}