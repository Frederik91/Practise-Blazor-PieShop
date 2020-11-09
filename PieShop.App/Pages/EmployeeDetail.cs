using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PieShop.App.Services;
using PieShop.ComponentsLibrary.Map;
using PieShop.Shared;

namespace PieShop.App.Pages
{
    public partial class EmployeeDetail
    {
        [Parameter]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = new Employee();

        [Inject] private IEmployeeDataService EmployeeDataService { get; set; }

        public List<Marker> MapMarkers { get; set; } = new List<Marker>();

        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(EmployeeId);
            MapMarkers = new List<Marker>
            {
                new Marker
                {
                    X = Employee.Longitude, 
                    Y = Employee.Latitude,
                    Description = Employee.FirstName + " " + Employee.LastName,
                    ShowPopup = false
                }
            };
        }
    }
}
