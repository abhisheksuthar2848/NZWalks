using Microsoft.Extensions.FileProviders;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.API.Models.Domain
{
    public class Image
    {
        public Guid Id { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public int FileExtenction { get; set; }
        public int FileDescription { get; set; }
    }
}
