using System.ComponentModel.DataAnnotations;


namespace DogsHouseService.Models
{
    public class Dog
    {
        [Key]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Color { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Tail length can`t be negative")]
        public int TailLength { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Weight can`t be negative")]
        public int Weight { get; set; }

    }
}
