using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories.Interface;
using NZWalks.API.CustomActionFilters;
using Microsoft.AspNetCore.Authorization;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalksRepository walksRepository;

        public WalksController(IMapper mapper, IWalksRepository walksRepository)
        {
            this.mapper = mapper;
            this.walksRepository = walksRepository;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
           
                var walkDomainModel = mapper.Map<Walk>(addWalkRequestDTO);
                await walksRepository.CreateAsync(walkDomainModel);

                return Ok(mapper.Map<WalkDTO>(walkDomainModel));
             //return BadRequest();
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, 
            [FromQuery] string? sortby, [FromQuery] bool? IsAccending,
            [FromQuery] int pageNumber =1, [FromQuery] int paeSize=1000)
        {
          

            var walkDomainModel = await walksRepository.GetAllAsync(filterOn, filterQuery, sortby,IsAccending?? true,pageNumber,paeSize);
            return Ok(mapper.Map<List<WalkDTO>>(walkDomainModel));
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {
            var WalkDomainModel = await walksRepository.GetByIdAsync(Id);
            if (WalkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDTO>(WalkDomainModel));
        }

        [HttpPut]
        [ValidateModel]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateWalkRequestDTO updateWalkRequestDTO)
        {
           
                var WalkDomainModel = mapper.Map<Walk>(updateWalkRequestDTO);
                WalkDomainModel = await walksRepository.UpdateAsync(id, WalkDomainModel);
                if (WalkDomainModel == null)
                {
                    return null;
                }
                return Ok(mapper.Map<WalkDTO>(WalkDomainModel));
           
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return Ok(await walksRepository.DeleteAsync(id));
        }
    }
}
