using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PieShop.App.Services;
using PieShop.Shared;

namespace PieShop.App.Components
{
    public partial class AddEmployeeDialog
    {
        public Employee Employee { get; set; } = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };

        [Inject] private IEmployeeDataService EmployeeDataService { get; set; }

        public bool ShowDialog { get; set; }

        [Parameter] public EventCallback<bool> CloseEventCallback { get; set; }

        public void Show()
        {
            ResetDialog();
            ShowDialog = true;
            StateHasChanged();
        }
        
        private async Task Close(bool state)
        {
            await CloseEventCallback.InvokeAsync(state);
            ShowDialog = false;
            StateHasChanged();
        }

        private void ResetDialog()
        {
            Employee = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };
        }

        private async Task HandleValidSubmit()
        {
            await EmployeeDataService.AddEmployee(Employee);
            await Close(true);
        }
    }
}