using AquaZooAPI.Models;
using AquaZooAPI.Models.DataTransfer;
using AquaZooAPI.Repository;
using AquaZooAPI.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AquaZooAPI.Controllers
{
    [Route("api/Programs")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public class LocationProgramController : ControllerBase
    {
        private ILocationProgramRepository _repositry;
        private readonly IMapper _mapper;

        public LocationProgramController(ILocationProgramRepository repository , IMapper mapper)
        {
            _repositry = repository;
            _mapper = mapper; 
        }

        [HttpGet]
        [ProducesResponseType(200, Type= typeof(List<LocationProgramEntityDto>))]
        [ProducesResponseType(400)]
        [ProducesDefaultResponseType]
        public  IActionResult GetAllPrograms()
        {
            var list = _repositry.GetAllLocationProgramEntities(); ;

            var dtoList = new List<LocationProgramEntityDto>();

            foreach(var item in list)
                dtoList.Add(_mapper.Map<LocationProgramEntityDto>(item)); 

            return Ok(dtoList); 
        }

        

        [HttpGet("{AquaZooId}/Locations")]
        [ProducesResponseType(200, Type = typeof(List<LocationProgramEntityDto>))]
        [ProducesResponseType(400)]
        [ProducesDefaultResponseType]
        public IActionResult GetLocationsInPrograms(int AquaZooId)
        {
            var list = _repositry.GetLocationsInPrograms(AquaZooId);

            var dtoList = new List<LocationProgramEntityDto>();

            foreach (var item in list)
                dtoList.Add(_mapper.Map<LocationProgramEntityDto>(item));

            return Ok(dtoList);
        }



        [HttpGet("{Id}", Name = "GetProgramDetail")]
        [ProducesResponseType(200, Type = typeof(LocationProgramEntityDto))]
        [ProducesResponseType(400)]
        [ProducesDefaultResponseType]
        public IActionResult GetProgramDetail(int Id)
        {
            LocationProgramEntityDto objDto = null;
            LocationProgramEntity locationProgramEntity = null;

            locationProgramEntity = _repositry.GetLocationProgramEntity(Id);
            if (locationProgramEntity != null)
            {
                objDto=  _mapper.Map<LocationProgramEntityDto>(locationProgramEntity);
            }

            if (objDto != null)
                return Ok(objDto);
            else
                return NotFound(); 

        }

        

         

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(LocationProgramEntityDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesDefaultResponseType]
        public IActionResult CreateLocationProgram([FromBody] LocationProgramCreateDto data)
        {
            if ( data == null )
                return BadRequest(ModelState);

             LocationProgramEntity locationProgramEntity = _mapper.Map<LocationProgramEntity>(data); 
            bool result=   _repositry.CreateOrUpdateLocationProgramEntity(locationProgramEntity);

            if (result)
                return Ok( locationProgramEntity); 
            else
                return StatusCode(500); 
            
        }

       


        [HttpPatch]
        [ProducesResponseType(204, Type = typeof(LocationProgramEntityDto))]
        [ProducesResponseType(500)]
        [ProducesDefaultResponseType]
        public IActionResult UpdateLocationProgram([FromBody] LocationProgramUpdateDto data)
        {
            if (data == null || data.Id <= 0 )
                return BadRequest(ModelState);

            LocationProgramEntity locationProgramEntity = _mapper.Map<LocationProgramEntity>(data);
            bool result = _repositry.CreateOrUpdateLocationProgramEntity(locationProgramEntity);

            if (result)
                return Ok(locationProgramEntity);
            else
                return StatusCode(500);

        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(204, Type = typeof(LocationProgramEntityDto))]
        [ProducesResponseType(500)]
        [ProducesDefaultResponseType]
        public IActionResult DeleteAquaZooDetail(int Id)
        {
            if (Id <= 0)
                return BadRequest();

            bool result = _repositry.DeleteLocationProgramEnttity(Id);

            if (result)
                return NoContent();
            else
                return NotFound(); 


        }

    }
}
