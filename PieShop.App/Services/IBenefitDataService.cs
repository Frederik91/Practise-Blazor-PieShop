using System.Collections.Generic;
using System.Threading.Tasks;
using PieShop.Shared;

namespace PieShop.App.Services
{
    public interface IBenefitDataService
    {
        Task<IEnumerable<BenefitModel>> GetForEmployee(Employee employee);
        Task UpdateForEmployee(Employee employee, IEnumerable<BenefitModel> benefits);
    }
}