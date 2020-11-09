using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PieShop.App.Services;
using PieShop.Shared;

namespace PieShop.App.Pages
{
    public partial class EmployeeDetail
    {
        [Parameter]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = new Employee();

        [Inject] private IEmployeeDataService EmployeeDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(EmployeeId);
        }
    }
}
