using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace SchoolAPI.Controllers
{
    [Route("api/v1/organizations")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public OrganizationsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOrganizations()
        {

                var organizations = _repository.Organization.GetAllOrganizations(trackChanges: false);

                var organizationDto = _mapper.Map<IEnumerable<OrganizationDto>>(organizations);
            //uncomment the code below to test the global exception handling
            //throw new Exception("Exception");
            return Ok(organizationDto);
        }
        [HttpGet("{id}")]
        public IActionResult GetOrganizationy(Guid id)
        {
            try
            {
                var organization = _repository.Organization.GetOrganization(id, trackChanges: false); if (organization == null)
                {
                    _logger.LogInfo($"Organization with id: {id} doesn't exist in the database.");
                    return NotFound();
                }
                else
                {
                    var organizationDto = _mapper.Map<OrganizationDto>(organization);
                    return Ok(organizationDto);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetOrganizations)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
           
        }
    }
}