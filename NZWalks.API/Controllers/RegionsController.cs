using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories.Interface;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize] 
    public class RegionsController : ControllerBase
    {   

        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper,
            ILogger<RegionsController> logger
            
            )
        {

            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            logger.LogInformation("getAll logger method invoked");

            //get data from database -domin model
            var regionsDomain = await regionRepository.GetAllAsync();

            // map domain model to DTOs
            //var regionsDto = new List<RegionDTO>();
            //foreach (var item in regionsDomain)
            //{
            //    regionsDto.Add(
            //        new RegionDTO
            //        {
            //            Id = item.Id,
            //            Name = item.Name,
            //            Code = item.Code,
            //            RegionImageUrl = item.RegionImageUrl
            //        });
            //}


            var regionsDto = mapper.Map<List<RegionDTO>>(regionsDomain);


            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> Get(Guid id)
        {
            var regionDomain = await regionRepository.GetAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            //var regionDTO = new RegionDTO
            //{
            //    Id = regionDomain.Id,
            //    Name = regionDomain.Name,
            //    Code = regionDomain.Code,
            //    RegionImageUrl = regionDomain.RegionImageUrl
            //};

            var regionDTO = mapper.Map<RegionDTO>(regionDomain);


            return Ok(regionDTO);
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDTO addRegionRequestDTO)
         {
            
                //var regionDomainModel = new Region()
                //{
                //    //Id = Guid.NewGuid(),
                //    Name = addRegionRequestDTO.Name,
                //    Code = addRegionRequestDTO.Code,
                //    RegionImageUrl = addRegionRequestDTO.RegionImageUrl
                //};

                var regionDomainModel = mapper.Map<Region>(addRegionRequestDTO);

                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);


                //var regionDto = new RegionDTO
                //{
                //    Id = regionDomainModel.Id,
                //    Name = regionDomainModel.Name,
                //    Code = regionDomainModel.Code,
                //    RegionImageUrl = regionDomainModel.RegionImageUrl
                //};

                var regionDto = mapper.Map<RegionDTO>(regionDomainModel);

                //return CreatedAtAction(nameof(Get),new {id=123},regionDto );
                return CreatedAtAction(nameof(Get), new { id = regionDomainModel.Id }, regionDto); 
           
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
        {
           
                // Map DTO to Domain Model
                //var regionDomainModel = new Region
                //{
                //    Code = updateRegionRequestDTO.Code,
                //    Name = updateRegionRequestDTO.Name,
                //    RegionImageUrl = updateRegionRequestDTO.RegionImageUrl
                //};

                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDTO);

                regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);
                if (regionDomainModel == null)
                {
                    return NotFound();
                }

                //Convert Domin Model to Dto
                //var regionDto = new RegionDTO
                //{
                //    Id = regionDomainModel.Id,
                //    Name = regionDomainModel.Name,
                //    Code = regionDomainModel.Code, 
                //    RegionImageUrl = regionDomainModel.RegionImageUrl
                //};

                var regionDto = mapper.Map<RegionDTO>(regionDomainModel);

                return Ok(regionDto); 
          
           
        }

        //Delete Region
        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);


            if (regionDomainModel == null)
            {
                return NotFound();
            }
            return Ok();

        }
    }
}
