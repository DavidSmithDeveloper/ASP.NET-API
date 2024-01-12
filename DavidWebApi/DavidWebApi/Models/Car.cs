using System.ComponentModel.DataAnnotations;

namespace DavidWebApi.Models
{
    public class Car
    {
        public int CarId { get; set; }

        [Required]
        public string? Make { get; set; }
        
        [Required]
        public string? Model { get; set; }

       
        public int? Doors { get; set; }

        public string? Color { get; set; }
        
        [Required]
        public double? Price { get; set; }



    }
}
