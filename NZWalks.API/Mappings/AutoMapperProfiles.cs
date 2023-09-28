using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using System.Globalization;

namespace NZWalks.API.Mappings
{
    public class AutoMapperProfiles:Profile 
    {

        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<AddRegionRequestDTO, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDTO, Region>().ReverseMap();
            CreateMap<AddWalkRequestDTO, Walk>().ReverseMap();
            CreateMap<Walk, WalkDTO>().ReverseMap();
            CreateMap<DifficultyDTO, Difficulty>().ReverseMap();
            CreateMap<Walk,UpdateWalkRequestDTO>().ReverseMap();
        }
    }
}
