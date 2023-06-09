using System.ComponentModel.DataAnnotations;

namespace backend.Data.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(256)]
        public string Fullname { get; set; }
        
        [Required]
        [MaxLength(256)]
        public string Phone { get; set; }
        
        [Required]
        public byte[] PasswordHash { get; set; }
        
        [Required]
        public byte[] PasswordSalt { get; set; }
        
        [MaxLength(256)]
        public string Email { get; set; }
        
        public DateTime CreateAt { get; set; }
        
        public DateTime UpdateAt { get; set; }

        public int RoleId { get; set; }
        
        public Role Role { get; set; }
        
        public Restaurant? Restaurant { get; set; }

        public List<Reservation>? Reservations { get; set; }
        
        

    }
}