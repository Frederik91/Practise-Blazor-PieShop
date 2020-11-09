using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PieShop.Api.Models;
using PieShop.Shared;

namespace PieShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenefitController: Controller
    {
        private readonly IBenefitRepository _benefitRepository;

        public BenefitController(IBenefitRepository benefitRepository)
        {
            _benefitRepository = benefitRepository;
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetForEmployee(int employeeId)
        {
            return Ok(_benefitRepository.GetForEmployee(employeeId));
        }

        [HttpPost("{employeeId}")]
        public void UpdateForEmployee(int employeeId, List<BenefitModel> model)
        {
            _benefitRepository.UpdateForEmployee(employeeId, model);
        }
    }
}
