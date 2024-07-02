using eStoreClient.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Metrics;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using BusinessObject.Models;

namespace maiClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public LoginViewModel LoginModel { get; set; }

        [ViewData]
        public string Message { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> OnPost()
        {
            try
            {
                HttpClient client = new();
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string CustomerApiUrl = "https://localhost:7278/api/BranchAccount/Login";
                string param = $"?email={LoginModel.Email}&password={LoginModel.Password}";
                HttpContent content = new StringContent(param, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(CustomerApiUrl + param, content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string strData = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var result = JsonSerializer.Deserialize<BranchAccount>(strData, options);
                    //HttpContext.Session.SetInt32("id", result.AccountId);
                    //return RedirectToPage("/BranchAccounts/Index");
                    if(result.Role == 1)
                    {
                        return RedirectToPage("/BranchAccounts/Index");
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return RedirectToPage("/Customers/Index");
                }
                else
                {
                    Message = "You are not allowed to access this function!";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Page();
        }
    }
}
