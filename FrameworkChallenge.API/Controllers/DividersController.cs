using FrameworkChallenge.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace FrameworkChallengeNet5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DividersController : Controller
    {
        private readonly ILogger<DividersController> _logger;

        private readonly IDistributedCache _cache;

        public DividersController(ILogger<DividersController> logger, IDistributedCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        [HttpGet]
        public DividersDTO Get(int number)
        {
            try
            {
                CalculatorDividers _calculate = new();
                var calculateDivider = _calculate.Calculate(number);
                _cache.SetString("_" + number, "Result" + calculateDivider);

                return calculateDivider;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}