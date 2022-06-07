using System.ComponentModel.DataAnnotations;

namespace Zad2.Model
{
    public class Animal
    {
        public int IdAnimal { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Description { get; set; }
        public string Category { get; set; }
        public string Area { get; set; }
    }
}
