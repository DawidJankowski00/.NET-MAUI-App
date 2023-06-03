using System.ComponentModel.DataAnnotations;

namespace Food.Model
{
    public class ComponentProduct
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }  
        public int ComponentId { get; set; }
    }
}
