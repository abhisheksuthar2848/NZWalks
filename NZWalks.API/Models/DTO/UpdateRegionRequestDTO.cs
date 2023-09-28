using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class UpdateRegionRequestDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(3,ErrorMessage ="Code max minimum 3 charecter")]
        [MinLength (3,ErrorMessage ="Code minumam have 3 charecter")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100,ErrorMessage ="Name maximum length is 100")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
