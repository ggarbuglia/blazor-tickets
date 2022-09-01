using AutoMapper;
using BlazorTickets.Contracts;
using BlazorTickets.DataObjects;
using BlazorTickets.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlazorTickets.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<TicketsController> _logger;
        private readonly IMapper _mapper;

        public TicketsController(IUnitOfWork unitOfWork, ILogger<TicketsController> logger, IMapper mapper)
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
                var entities = await _unitOfWork.Ticket.GetAll();
                return Ok(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: {Message}", ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            try
            {
                _logger.LogDebug("Retrieving entity data by id");
                var entity = await _unitOfWork.Ticket.GetById(id);
                if (entity == null)
                {
                    _logger.LogError("Object with {id} not found", id);
                    return NotFound($"Object with {id} not found");
                }

                return Ok(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: {Message}", ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TicketDto ticket)
        {
            try
            {
                if (ticket == null)
                {
                    _logger.LogError("Object is null");
                    return BadRequest("Object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Object model is invalid");
                    return BadRequest("Object model is invalid");
                }

                var entity = _mapper.Map<Ticket>(ticket);
                entity.Id = Guid.NewGuid();
                entity.CreatedOn = DateTime.Now;

                _logger.LogDebug("Creating object");
                _unitOfWork.Ticket.Create(entity);
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
        public async Task<ActionResult> Update(Guid id, [FromBody] TicketDto ticket)
        {
            try
            {
                if (ticket == null)
                {
                    _logger.LogError("Object is null");
                    return BadRequest("Object is null");
                }

                if (ticket.Id != id)
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
                var entity = await _unitOfWork.Ticket.GetById(id);
                if (entity == null)
                {
                    _logger.LogError("Object with {id} not found", id);
                    return NotFound($"Object with {id} not found");
                }

                _logger.LogDebug("Mapping DTO object");
                _mapper.Map(ticket, entity);
                entity.UpdatedOn = DateTime.Now;

                _logger.LogDebug("Updating object");
                _unitOfWork.Ticket.Update(entity);
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
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                _logger.LogDebug("Retrieving entity data by id");
                var entity = await _unitOfWork.Ticket.GetById(id);
                if (entity == null)
                {
                    _logger.LogError("Object with {id} not found", id);
                    return NotFound($"Object with {id} not found");
                }

                _logger.LogDebug("Removing object");
                _unitOfWork.Ticket.Remove(entity);
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
