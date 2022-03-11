using AquaZooAPI.Models;
using AquaZooAPI.Models.DataTransfer;
using AquaZooAPI.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AquaZooAPI.Repository.IRepository;


namespace AquaZooAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public class AquaZooV2Controller : ControllerBase
    {
        private IAquaZooRepository _repositry;
        private readonly IMapper _mapper;

        public AquaZooV2Controller(IAquaZooRepository repository , IMapper mapper)
        {
            _repositry = repository;
            _mapper = mapper; 
        }

        [HttpGet]
        [ProducesResponseType(200, Type= typeof(List<AquaZooEntityDto>))]
        [ProducesResponseType(400)]
        [ProducesDefaultResponseType]
        public  IActionResult GetAllAquaZooData()
        {
            var item = _repositry.GetAquaZooEntities().FirstOrDefault();

            var dtoObj = new AquaZooEntityDto();


            dtoObj = _mapper.Map<AquaZooEntityDto>(item); 

            return Ok(dtoObj); 
        }

        
        
        

    }
}
