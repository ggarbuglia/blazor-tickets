using AutoMapper;
using BlazorTickets.Domain.Contracts;
using BlazorTickets.DataObjects;
using BlazorTickets.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlazorTickets.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketTypesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<TicketTypesController> _logger;
        private readonly IMapper _mapper;

        public TicketTypesController(IUnitOfWork unitOfWork, ILogger<TicketTypesController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var entities = await _unitOfWork.TicketType.GetAll();
                var dobjects = _mapper.Map<IEnumerable<TicketTypeDto>>(entities);
                return Ok(dobjects);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: {Message}", ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                _logger.LogDebug("Retrieving entity data by id");
                var entity = await _unitOfWork.TicketType.GetById(id);
                if (entity == null)
                {
                    _logger.LogError("Object with {id} not found", id);
                    return NotFound($"Object with {id} not found");
                }

                var dobject = _mapper.Map<TicketTypeDto>(entity);
                return Ok(dobject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: {Message}", ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]TicketTypeDto ticketType)
        {
            try
            {
                if (ticketType == null)
                {
                    _logger.LogError("Object is null");
                    return BadRequest("Object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Object model is invalid");
                    return BadRequest("Object model is invalid");
                }
                var entity = _mapper.Map<TicketType>(ticketType);
                entity.CreatedOn = DateTime.Now;

                _logger.LogDebug("Creating object");
                _unitOfWork.TicketType.Create(entity);
                await _unitOfWork.SaveAsync();
                _logger.LogDebug("Object created");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: {Message}", ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody]TicketTypeDto ticketType)
        {
            try
            {
                if (ticketType == null)
                {
                    _logger.LogError("Object is null");
                    return BadRequest("Object is null");
                }

                if (ticketType.Id != id)
                {
                    _logger.LogError("Id and Object Id dont match");
                    return BadRequest("Id and Object Id dont match");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Object model is invalid");
                    return BadRequest("Object model is invalid");
                }

                _logger.LogDebug("Retrieving entity data by id");
                var entity = await _unitOfWork.TicketType.GetById(id);
                if (entity == null)
                {
                    _logger.LogError("Object with {id} not found", id);
                    return NotFound($"Object with {id} not found");
                }

                _logger.LogDebug("Mapping DTO object");
                _mapper.Map(ticketType, entity);
                entity.UpdatedOn = DateTime.Now;

                _logger.LogDebug("Updating object");
                _unitOfWork.TicketType.Update(entity);
                await _unitOfWork.SaveAsync();
                _logger.LogDebug("Object updated");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: {Message}", ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                _logger.LogDebug("Retrieving entity data by id");
                var entity = await _unitOfWork.TicketType.GetById(id);
                if (entity == null)
                {
                    _logger.LogError("Object with {id} not found", id);
                    return NotFound($"Object with {id} not found");
                }

                _logger.LogDebug("Removing object");
                _unitOfWork.TicketType.Remove(entity);
                await _unitOfWork.SaveAsync();
                _logger.LogDebug("Object removed");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: {Message}", ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
