using AquaZooAPI.Models;
using AquaZooAPI.Models.DataTransfer;
using AquaZooAPI.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AquaZooAPI.Repository.IRepository;


namespace AquaZooAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public class AquaZooController : ControllerBase
    {
        private IAquaZooRepository _repositry;
        private readonly IMapper _mapper;

        public AquaZooController(IAquaZooRepository repository , IMapper mapper)
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
            var list = _repositry.GetAquaZooEntities();

            var dtoList = new List<AquaZooEntityDto>();

            foreach(var item in list)
                dtoList.Add(_mapper.Map<AquaZooEntityDto>(item)); 

            return Ok(dtoList); 
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(AquaZooEntityDto))]
        [ProducesResponseType(400)]
        [ProducesDefaultResponseType]
        public IActionResult GetAquaZooDetail(int Id)
        {
            AquaZooEntityDto objDto = null;
            AquaZooEntity aquaZooEntity = null;

            aquaZooEntity = _repositry.GetAquaZooEntity(Id);
            if (aquaZooEntity != null)
            {
                objDto=  _mapper.Map<AquaZooEntityDto>(aquaZooEntity);
            }

            if (objDto != null)
                return Ok(objDto);
            else
                return NotFound(); 

        }
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(AquaZooEntityDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesDefaultResponseType]
        public IActionResult CreateAquaZoo([FromBody] AquaZooEntityDto data)
        {
            if ( data == null )
                return BadRequest(ModelState);

             AquaZooEntity aquaZooEntity = _mapper.Map<AquaZooEntity>(data); 
            bool result=   _repositry.CreateOrUpdateAquaZooEntity(aquaZooEntity);

            if (result)
                return Ok( aquaZooEntity); 
            else
                return StatusCode(500); 
            
        }

        [HttpPatch]
        [ProducesResponseType(204, Type = typeof(AquaZooEntityDto))]
        [ProducesResponseType(500)]
        [ProducesDefaultResponseType]
        public IActionResult UpdateAquaZoo([FromBody] AquaZooEntityDto data)
        {
            if (data == null || data.AquaZooId <= 0 )
                return BadRequest(ModelState);

            AquaZooEntity aquaZooEntity = _mapper.Map<AquaZooEntity>(data);
            bool result = _repositry.CreateOrUpdateAquaZooEntity(aquaZooEntity);

            if (result)
                return Ok(aquaZooEntity);
            else
                return StatusCode(500);

        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(204, Type = typeof(AquaZooEntityDto))]
        [ProducesResponseType(500)]
        [ProducesDefaultResponseType]
        public IActionResult DeleteAquaZooDetail(int Id)
        {
            if (Id <= 0)
                return BadRequest();

            bool result = _repositry.DeleteAquaZooEnttity(Id);

            if (result)
                return NoContent();
            else
                return NotFound(); 


        }

    }
}
