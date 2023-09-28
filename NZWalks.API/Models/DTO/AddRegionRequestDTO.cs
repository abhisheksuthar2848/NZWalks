using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class AddRegionRequestDTO
    {
        [Required]
        [MinLength(3,ErrorMessage ="Code have min 3 length")]
        [MaxLength(3,ErrorMessage ="Code have maximum 3 length")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100,ErrorMessage ="Name have maximum 100 Character")]
        public string Name { get; set; }
        
        public string? RegionImageUrl { get; set; }
    }
}
