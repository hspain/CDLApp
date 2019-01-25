﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CieDigitalAssessment.DAL;
using CieDigitalAssessment.API.Models;

namespace CieDigitalAssessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ApiController<Customer>
    {
        public CustomersController(IApplicationRepository<Customer> repository) : base(repository)
        {

        }
    }
}