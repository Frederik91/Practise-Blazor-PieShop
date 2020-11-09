using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PieShop.App.Components;
using PieShop.App.Services;
using PieShop.Shared;

namespace PieShop.App.Pages
{
    public partial class EmployeeOverview
    {
		public IEnumerable<Employee> Employees { get; set; }

        [Inject] public IEmployeeDataService EmployeeDataService { get; set; }

        protected AddEmployeeDialog AddEmployeeDialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employees = await EmployeeDataService.GetAllEmployees();
        }

        private void QuickAddEmployee()
        {
            AddEmployeeDialog.Show();
        }

        private async void OnDialogClose(bool result)
        {
            if (!result)
                return;

            Employees = await EmployeeDataService.GetAllEmployees();
            StateHasChanged();
        }
    }
}