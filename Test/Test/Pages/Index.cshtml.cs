using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test.Models;

namespace Test.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _client;
        private readonly string _authorizationUrl;
        private readonly string _sendTokenUrl;
        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_configuration["Urls:Base"]);
            _authorizationUrl = _configuration["Urls:Authorization"];
            _sendTokenUrl = _configuration["Urls:SendToken"];
        }

        private AuthorizationResponse? AuthorizationData { get; set; }

        public CommandsList? CommandsList { get; set; }
        [BindProperty]
        public Command CurrentCommand { get; set; }
        public SelectList Options { get; set; }
        public async void OnGetAsync()
        {
            AuthorizationData = await _client.GetFromJsonAsync<AuthorizationResponse>(_authorizationUrl);
            CommandsList = await _client.GetFromJsonAsync<CommandsList>(_sendTokenUrl + AuthorizationData.Token);
            Options = new SelectList(CommandsList.Commands,
                nameof(Command.Id),
                nameof(Command.Name),
                CurrentCommand);

            foreach (var command in CommandsList.Commands)
            {
                await Console.Out.WriteLineAsync(command.Name);
            }
            await Console.Out.WriteLineAsync(CurrentCommand?.Name ?? "NULL");
        }
    }
}