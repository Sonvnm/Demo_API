using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using System.Diagnostics.Metrics;
using System.Net.Http.Headers;
using System.Text.Json;

namespace maiClient.Pages.BranchAccounts
{
    public class IndexModel : PageModel
    {
        private HttpClient client = null;
        private string CustomerApiUrl = "";
        public IndexModel() { }
        public IList<BranchAccount> BranchAccount { get; set; }
        [BindProperty]
        public string SearchString { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            CustomerApiUrl = "https://localhost:7278/api/BranchAccount/GetAll";
            HttpResponseMessage response = await client.GetAsync(CustomerApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            BranchAccount = JsonSerializer.Deserialize<IList<BranchAccount>>(strData, options);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            CustomerApiUrl = "https://localhost:7212/api/Member/Search";
            string param = $"?name={SearchString}";
            HttpResponseMessage response = await client.GetAsync(CustomerApiUrl + param);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            BranchAccount = JsonSerializer.Deserialize<IList<BranchAccount>>(strData, options);
            return Page();
        }
    }
}
