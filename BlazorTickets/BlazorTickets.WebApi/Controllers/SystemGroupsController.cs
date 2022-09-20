using AutoMapper;
using BlazorTickets.Domain.Contracts;
using BlazorTickets.DataObjects;
using BlazorTickets.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlazorTickets.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemGroupsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SystemGroupsController> _logger;
        private readonly IMapper _mapper;

        public SystemGroupsController(IUnitOfWork unitOfWork, ILogger<SystemGroupsController> logger, IMapper mapper)
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
                var entities = await _unitOfWork.SystemGroup.GetAll();
                var dobjects = _mapper.Map<IEnumerable<SystemGroupDto>>(entities);
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
                var entity = await _unitOfWork.SystemGroup.GetById(id);
                if (entity == null)
                {
                    _logger.LogError("Object with {id} not found", id);
                    return NotFound($"Object with {id} not found");
                }

                var dobject = _mapper.Map<SystemGroupDto>(entity);
                return Ok(dobject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: {Message}", ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] SystemGroupDto systemGroup)
        {
            try
            {
                if (systemGroup == null)
                {
                    _logger.LogError("Object is null");
                    return BadRequest("Object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Object model is invalid");
                    return BadRequest("Object model is invalid");
                }

                var entity = _mapper.Map<SystemGroup>(systemGroup);
                entity.CreatedOn = DateTime.Now;

                _logger.LogDebug("Creating object");
                _unitOfWork.SystemGroup.Create(entity);
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
        public async Task<ActionResult> Update(int id, [FromBody] SystemGroupDto systemGroup)
        {
            try
            {
                if (systemGroup == null)
                {
                    _logger.LogError("Object is null");
                    return BadRequest("Object is null");
                }

                if (systemGroup.Id != id)
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
                var entity = await _unitOfWork.SystemGroup.GetById(id);
                if (entity == null)
                {
                    _logger.LogError("Object with {id} not found", id);
                    return NotFound($"Object with {id} not found");
                }

                _logger.LogDebug("Mapping DTO object");
                _mapper.Map(systemGroup, entity);
                entity.UpdatedOn = DateTime.Now;

                _logger.LogDebug("Updating object");
                _unitOfWork.SystemGroup.Update(entity);
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
                var entity = await _unitOfWork.SystemGroup.GetById(id);
                if (entity == null)
                {
                    _logger.LogError("Object with {id} not found", id);
                    return NotFound($"Object with {id} not found");
                }

                _logger.LogDebug("Removing object");
                _unitOfWork.SystemGroup.Remove(entity);
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
