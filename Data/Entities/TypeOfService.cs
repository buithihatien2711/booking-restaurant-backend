using System.ComponentModel.DataAnnotations;

namespace backend.Data.Entities
{
    public class TypeOfService
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public List<RestaurantService>? RestaurantServices { get; set; }

        public TypeOfService() {}

        public TypeOfService(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}