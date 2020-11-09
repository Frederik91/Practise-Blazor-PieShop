using Microsoft.AspNetCore.Components;
using PieShop.Shared;

namespace PieShop.App.Components
{
    public class EmployeeRowBase: ComponentBase
    { 
        [Parameter]
        public Employee Employee { get; set; }

        public void PremiumToggle(bool premiumBenefit)
        {
            Employee.HasPremiumBenefits = premiumBenefit;
        }
    }
}
