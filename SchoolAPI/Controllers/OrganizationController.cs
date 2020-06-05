﻿using AutoMapper;
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
            //test the global exception handling
            //throw new Exception("Exception");
            return Ok(organizationDto);
        }
    }
}