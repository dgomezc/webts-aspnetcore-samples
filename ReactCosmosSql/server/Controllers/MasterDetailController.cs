﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiSql.Contracts;
using WebApiSql.Models;

namespace WebApiSql.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MasterDetailController : ControllerBase
    {
        private readonly ILogger<MasterDetailController> _logger;
        private readonly ISampleDataService _sampleDataService;

        public MasterDetailController(ILogger<MasterDetailController> logger, ISampleDataService sampleDataService)
        {
            _logger = logger;
            _sampleDataService = sampleDataService;
        }

        [HttpGet]
        public IEnumerable<SampleCompany> Get()
        {
            return _sampleDataService.GetSampleCompanies();
        }
    }
}
