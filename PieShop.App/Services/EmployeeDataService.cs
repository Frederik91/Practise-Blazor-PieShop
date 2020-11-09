using PieShop.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PieShop.App.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly HttpClient _httpClient;

        public EmployeeDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var employeeJson =
                new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/employee", employeeJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Employee>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public Task UpdateEmployee(Employee employee)
        {
            var employeeJson =
                new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            return _httpClient.PutAsync("api/employee", employeeJson);
        }

        public Task DeleteEmployee(int employeeId)
        {
            return _httpClient.DeleteAsync($"api/employee/{employeeId}");
        }

        public Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return _httpClient.GetFromJsonAsync<IEnumerable<Employee>>("api/employee", new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public Task<Employee> GetEmployeeDetails(int employeeId)
        {
            return _httpClient.GetFromJsonAsync<Employee>($"api/employee/{employeeId}", new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

       
    }
}
