using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoWebApp.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using System.Text;
using System.Diagnostics;

namespace ToDoWebApp.Pages
{
	public class EditModel : PageModel
    {
        // IHttpClientFactory set using dependency injection 
        private readonly IHttpClientFactory _httpClientFactory;

        public EditModel(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        // Add the data model and bind the form data to the page model properties
        [BindProperty]
        public ToDoModel ToDoModels { get; set; }


        // Retrieve the data to populate the form for editing
        public async Task OnGet(int id)
        {
 
            // Create the HTTP client using the ToDoAPI named factory
            var httpClient = _httpClientFactory.CreateClient("ToDoAPI");

            // Retrieve record information to populate the form
            using HttpResponseMessage response = await httpClient.GetAsync(id.ToString());

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response to populate the form
                using var contentStream = await response.Content.ReadAsStreamAsync();
                ToDoModels = await JsonSerializer.DeserializeAsync<ToDoModel>(contentStream);
            }
        }
		

		// Begin PUT operation code
        
        // End PUT operation code

	}
}

