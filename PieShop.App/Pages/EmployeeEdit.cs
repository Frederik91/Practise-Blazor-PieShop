using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PieShop.App.Services;
using PieShop.Shared;

namespace PieShop.App.Pages
{
    public partial class EmployeeEdit
    {
        [Inject] public IEmployeeDataService EmployeeDataService { get; set; }
        [Inject] public ICountryDataService CountryDataService { get; set; }
        [Inject] public IJobCategoryDataService JobCategoryDataService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        [Parameter] public int EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();

        public IEnumerable<Country> Countries { get; set; } = new List<Country>();
        public IEnumerable<JobCategory> JobCategories { get; set; } = new List<JobCategory>();

        public string Message { get; set; } = string.Empty;
        public string StatusClass { get; set; } = string.Empty;
        public bool Saved { get; set; }


        public string JobCategoryId { get; set; }
        public string CountryId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Saved = false;
            Countries = await CountryDataService.GetAllCountries();
            JobCategories = await JobCategoryDataService.GetAllJobCategories();

            if (EmployeeId == 0)
                Employee = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };
            else
                Employee = await EmployeeDataService.GetEmployeeDetails(EmployeeId);

            JobCategoryId = Employee.JobCategoryId.ToString();
            CountryId = Employee.CountryId.ToString();
        }

        private void OnInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = $"There are some validation errors, please try again.";
        }

        private async Task OnValidSubmit()
        {
            Saved = false;
            Employee.CountryId = int.Parse(CountryId);
            Employee.JobCategoryId = int.Parse(JobCategoryId);
            if (EmployeeId == 0)
            {
                try
                {
                    var addedEmployee = await EmployeeDataService.AddEmployee(Employee);
                    if (addedEmployee != null)
                    {
                        StatusClass = "alert-success";
                        Message = $"{addedEmployee.FirstName} was added";
                        Saved = true;
                    }
                    else
                    {
                        StatusClass = "alert-danger";
                        Message = "Something went wrong, please try again";
                        Saved = false;
                    }
                }
                catch (Exception e)
                {
                    StatusClass = "alert-danger";
                    Message = e.Message;
                    Saved = false;
                }


            }
            else
            {
                try
                {
                    await EmployeeDataService.UpdateEmployee(Employee);
                    StatusClass = "alert-success";
                    Message = $"{Employee.FirstName} was updated";
                    Saved = true;
                }
                catch (Exception)
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong, please try again";
                    Saved = false;
                }
      
            }
     
        }

        private async Task DeleteEmployee()
        {
            try
            {
                await EmployeeDataService.DeleteEmployee(EmployeeId);
                StatusClass = "alert-success";
                Message = $"{Employee.FirstName} was deleted";
                Saved = true;

            }
            catch (Exception)
            {
                StatusClass = "alert-danger";
                Message = $"Something went wrong deleting {Employee.FirstName}";
                Saved = false;
            }
        }

        private void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/employeeoverview");
        }
    }
}