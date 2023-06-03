using System.ComponentModel.DataAnnotations;

namespace Food.Model
{
    public class UserComponent
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int ComponentId { get; set; }
    }
}
