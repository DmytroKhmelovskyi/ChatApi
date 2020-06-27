using ChatUI.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChatUI.Pages
{
    public class ChatsModel : PageModel
    {
        public List<ChatViewModel> Chats { get; set; }
        public async Task OnGetAsync()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:5001");
            var response = await httpClient.GetAsync("api/chat");
            if (response.IsSuccessStatusCode)
            {
                var chatsString = await response.Content.ReadAsStringAsync();
                Chats = JsonConvert.DeserializeObject<List<ChatViewModel>>(chatsString);
            }
        }
    }
}