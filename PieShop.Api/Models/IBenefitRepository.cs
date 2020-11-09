using System.Collections.Generic;
using PieShop.Shared;

namespace PieShop.Api.Models
{
    public interface IBenefitRepository
    {
        IEnumerable<BenefitModel> GetForEmployee(int employeeId);
        void UpdateForEmployee(int employeeId, IEnumerable<BenefitModel> model);
    }
}