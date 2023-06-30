using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Entities;
using backend.DTOs.RestaurantDTO;

namespace backend.Data.Repository.RestaurantRepository
{
    public interface IRestaurantRepository
    {
        List<Restaurant>? GetListRestaurant(string? filter, int page = 1);

        (List<Restaurant>?, int) FilterRestaurant(FilterRestaurantDto filter, int pageIndex);

        Restaurant? GetRestaurantById(Guid idRestaurant);

        Guid? GetRestaurantIdByUser(Guid idUser);

        bool IsSaveChange();

        void AddRestaurant(Restaurant restaurant);

        (List<Restaurant>, int) GetListRestaurantAdmin(int pageIndex, RestaurantStatus? status);

        // int GetTotalPage();

        void ChangeRestaurantStatus(Restaurant restaurant, RestaurantStatus status);
    }
}