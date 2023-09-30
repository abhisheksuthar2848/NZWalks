using NZWalks.API.Models.Domain;
using System.Net;

namespace NZWalks.API.Repositories.Interface
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
